using Hangfire;
using Meetings.API.Attributes;
using Meetings.API.Models;
using Meetings.API.Models.Common;
using Meetings.API.ObjectConverters.Interface.Unit;
using Meetings.Client.Interface.Unit;
using Meetings.Common.Enums;
using Meetings.Common.Helper;
using Meetings.Services.Interface.Unit;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Meetings.API.Controllers
{
    [ApiController]
    [CheckJwt(Allows = new AccountType[] { AccountType.Admin })]
    [Route("v1/events")]
    public class MeetingController : ControllerBase
    {
        #region Private Fields
        private readonly IClientUnit _client;
        private readonly IServiceUnit _service;
        private readonly IConverterUnit _converter;
        #endregion

        #region Private Methods

        #endregion

        #region Constructor
        public MeetingController(IClientUnit client, IConverterUnit converter, IServiceUnit service)
        {
            _client = client;
            _service = service;
            _converter = converter;
        }
        #endregion

        #region Properties

        #endregion

        #region Fields

        #endregion

        #region Methods

        #region EndPoints

        #region POST
        [HttpPost("run_job")]
        public ActionResult<ResponseWrapper<bool>> RunJob()
        {
            try
            {
                RecurringJob.AddOrUpdate("FetchEvents", () => _converter.Event.SyncEvents(), AppSettingHelper.GetCron());
                return Ok(new ResponseWrapper<bool>()
                {
                    Data = true,
                    Message = MessageHelper.SuccessfullyAdded,
                    Success = true
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseWrapper<object>
                {
                    Data = null,
                    Success = false,
                    Message = ex.Message
                });
            }
        }
        #endregion

        #region GET

        [HttpGet("fetch_and_show")]
        [CheckJwt(Allows = new[] { AccountType.Admin })]
        public ActionResult<List<CalenderEventResponse>> GetEventAndShow(CalendarPeriod? period)
        {
            var token = _converter.User.GetAdminToken(HttpContext);
            var user = _service.ById.GetUser(token.Id);

            try
            {
                int numDays = 1;
                if (period.HasValue)
                {
                    numDays = period switch
                    {
                        CalendarPeriod.Daily => 1,
                        CalendarPeriod.Weekly => 7,
                        CalendarPeriod.Monthly => 30,
                        CalendarPeriod.Period => 7,
                        _ => 1,
                    };
                }
                var startOfWeek = DateTime.UtcNow;
                DateTime endOfWeekUtc = startOfWeek.AddDays(numDays);

                var user_id = user.User_Id;

                if (string.IsNullOrWhiteSpace(user_id))
                {
                    user_id = _client.Graph.GetUserId(user.Email);
                    _service.User.AddUserId(user.Id, user_id);
                }
                var events = _client.Graph.GetEventsAsync(user_id, startOfWeek, endOfWeekUtc, 100, "IsAllDay eq false and IsCancelled eq false").Result;

                // for each event check the online meeting info and update accordingly
                foreach (var ev in events)
                {
                    //var getevent = await _graphClient.Users[userId].Events[cevent.Id]
                    //.Request()
                    //.Select("isOnlineMeeting,onlineMeetingProvider,onlineMeeting")
                    //.GetAsync();
                    //if (getevent.OnlineMeeting != null)
                    int startStr = ev.BodyContent.IndexOf(@"https://teams.microsoft.com");
                    if (startStr > 0)
                    {
                        int endStr = ev.BodyContent.IndexOf(" target=");
                        if (endStr - startStr > 1)
                            ev.WebLink = ev.BodyContent.Substring(startStr, endStr - startStr - 1);
                    }
                }


                foreach (var ev in events)
                {
                    var eventObject = _service.Event.AddCalenderEvent(ev.Subject, ev.Organizer?.EmailAddress?.Address,
                                                    ev.Organizer?.EmailAddress?.Name,
                                                    Convert.ToDateTime(ev.Start.DateTime),
                                                    Convert.ToDateTime(ev.End.DateTime), ev.WebLink, ev.ExtendedSubject,
                                                    ev.ExtendedClass, ev.ExtendedSchool, ev.ExtendedGrade, ev.EventId,
                                                    ev.BodyContent);

                    _service.UserEvent.AddUserEvent(eventObject.Id, user.Id);
                }



                return Ok(new ResponseWrapper<bool> { Data = true, Message = MessageHelper.SuccessfullyGet, Success = true });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseWrapper<object>
                {
                    Data = null,
                    Success = false,
                    Message = ex.Message
                });
            }
        }


        [HttpGet("")]
        [CheckJwt(Allows = new[] { AccountType.Admin })]
        public ActionResult<List<CalenderEventResponse>> GetEvents(CalendarPeriod? period,
                                                           string school, string grade, string subject,
                                                           string class_of_school, int? page_size,
                                                           int? page_index)
        {
            var token = _converter.User.GetAdminToken(HttpContext);
            var user = _service.ById.GetUser(token.Id);

            try
            {
                int numDays = 0;
                numDays = period switch
                {
                    CalendarPeriod.Daily => 1,
                    CalendarPeriod.Weekly => 7,
                    CalendarPeriod.Monthly => 30,
                    CalendarPeriod.Period => 7,
                    _ => 1,
                };


                var userEvents = _service.All.GetEvents().OrderBy(o => o.Start).Where(w => w.UserEvents.Any(a => a.User_Id == token.Id));
                if (period.HasValue)
                {
                    var start = DateTime.UtcNow.AddMinutes(-15);

                    var endOfWeekUtc = start;
                    endOfWeekUtc = period == CalendarPeriod.Daily ? new DateTime(start.Year, start.Month, start.Day, 23, 59, 59) : start.AddDays(numDays);

                    userEvents = userEvents.Where(w => w.Start >= start && w.End <= endOfWeekUtc);
                }


                if (!string.IsNullOrWhiteSpace(school))
                    userEvents = userEvents.Where(e => e.ExtendedSchool.Equals(school));
                if (!string.IsNullOrWhiteSpace(subject))
                    userEvents = userEvents.Where(e => e.ExtendedSubject.Equals(subject));
                if (!string.IsNullOrWhiteSpace(class_of_school))
                    userEvents = userEvents.Where(e => e.ExtendedClass.Equals(class_of_school));
                if (!string.IsNullOrWhiteSpace(grade))
                    userEvents = userEvents.Where(e => e.ExtendedGrade.Equals(grade));

                var total = 0;
                if (page_index.HasValue && page_size.HasValue && page_size.Value > 0)
                {
                    total = (int)Math.Ceiling(userEvents.Count() / (double)page_size.Value);
                    userEvents = userEvents.Skip(page_index.Value * page_size.Value).Take(page_size.Value);
                }


                var res = new PagedResponse<List<CalenderEventResponse>>()
                {
                    PageSize = page_size.Value,
                    PageNumber = page_index.Value,
                    TotalPages = total,
                    Data = new List<CalenderEventResponse>(),
                    Message = MessageHelper.SuccessfullyGet,
                    Success = true
                };

                foreach (var userEvent in userEvents)
                {
                    res.Data.Add(_converter.Event.GetEventResponse(userEvent));
                }

                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseWrapper<object>
                {
                    Data = null,
                    Success = false,
                    Message = ex.Message
                });
            }
        }
        #endregion

        #region PUT

        #endregion

        #region DELETE

        #endregion

        #endregion

        #endregion
    }
}
