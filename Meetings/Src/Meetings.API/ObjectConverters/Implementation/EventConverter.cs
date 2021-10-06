using ClosedXML.Excel;
using Meetings.API.Models;
using Meetings.API.ObjectConverters.Interface;
using Meetings.Client.Interface.Unit;
using Meetings.Common.Helper;
using Meetings.DTO.DbModels;
using Meetings.Services.Interface.Unit;
using System;
using System.Linq;

namespace Meetings.API.ObjectConverters.Implementation
{
    internal class EventConverter : IEventConverter
    {
        #region Private Fields
        private readonly IServiceUnit _service;
        private readonly IClientUnit _client;
        #endregion

        #region Private Methods

        #endregion

        #region Constructor
        public EventConverter(IServiceUnit service, IClientUnit client)
        {
            _service = service;
            _client = client;
        }
        #endregion

        #region Properties

        #endregion

        #region Fields

        #endregion

        #region Methods
        public CalenderEventResponse GetEventResponse(CalenderEvent e)
        {
            var res = new CalenderEventResponse
            {
                Subject = e.Subject,
                OrganizerEmail = e.OrganizerEmail,
                OrganizerName = e.OrganizerName,
                Start = e.Start.AddHours(AppSettingHelper.GetUtcDifference()),
                End = e.End.AddHours(AppSettingHelper.GetUtcDifference()),

                BodyContent = e.BodyContent,
                ExtendedClass = e.ExtendedClass,
                ExtendedSubject = e.ExtendedSubject,
                ExtendedSchool = e.ExtendedSchool,
                ExtendedGrade = e.ExtendedGrade,
                EventId = e.EventId,
                Id = e.Id
            };
            if (e.Start >= DateTime.UtcNow.AddMinutes(-15))
                res.WebLink = e.WebLink;

            return res;
        }

        public void GetExcelResponse(IXLWorksheet worksheet, int index, CalenderEvent userEvent)
        {
            worksheet.Cell(index, 1).Value = userEvent.Subject;
            worksheet.Cell(index, 2).Value = userEvent.Start;
            worksheet.Cell(index, 3).Value = userEvent.End;
            worksheet.Cell(index, 4).Value = userEvent.EventId;
            worksheet.Cell(index, 5).Value = userEvent.WebLink;
            worksheet.Cell(index, 6).Value = userEvent.ExtendedSubject;
            worksheet.Cell(index, 7).Value = userEvent.ExtendedSchool;
            worksheet.Cell(index, 8).Value = userEvent.ExtendedClass;
        }

        public void SyncEvents()
        {
            var users = _service.All.GetUsers().ToList();
            foreach (var user in users)
            {
                var user_id = user.User_Id;

                if (string.IsNullOrWhiteSpace(user_id))
                {
                    user_id = _client.Graph.GetUserId(user.Email);
                    _service.User.AddUserId(user.Id, user_id);
                }

                var start_of_week_utc = DateTime.UtcNow;
                var endOfWeekUtc = start_of_week_utc.AddDays(7);

                var events = _client.Graph.GetEventsAsync(user_id, start_of_week_utc, endOfWeekUtc, 100, "IsAllDay eq false and IsCancelled eq false").Result;

                // for each event check the online meeting info and update accordingly
                foreach (var ev in events)
                {
                    //var getevent = await _graphClient.Users[userId].Events[cevent.Id]
                    //.Request()
                    //.Select("isOnlineMeeting,onlineMeetingProvider,onlineMeeting")
                    //.GetAsync();
                    //if (getevent.OnlineMeeting != null)
                    if (!string.IsNullOrWhiteSpace(ev.BodyContent))
                    {
                        int startStr = ev.BodyContent.IndexOf(@"https://teams.microsoft.com");
                        if (startStr > 0)
                        {
                            int endStr = ev.BodyContent.IndexOf(" target=");
                            if (endStr - startStr > 1)
                                ev.WebLink = ev.BodyContent.Substring(startStr, endStr - startStr - 1);
                        }
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
            }
        }
        #endregion
    }
}
