using Meetings.DTO.DbModels;
using Meetings.Repositories.Interface.Unit;
using Meetings.Services.Implementation.GetServices;
using Meetings.Services.Interface;
using Meetings.Services.Interface.GetServices;
using System;
using System.Linq;

namespace Meetings.Services.Implementation
{
    internal class CalenderEventService : ICalenderEventService
    {
        #region Private Fields
        private readonly IRepositoryUnit _repo;
        private readonly IAllService _all;
        private readonly IByIdService _byId;
        #endregion

        #region Private Methods

        #endregion

        #region Constructor
        public CalenderEventService(IRepositoryUnit repo)
        {
            _repo = repo;
            _all = new AllService(_repo);
            _byId = new ByIdService(_repo);
        }
        #endregion

        #region Properties

        #endregion

        #region Fields

        #endregion

        #region Methods
        public CalenderEvent AddCalenderEvent(string subject, string organizer_email, string organizer_name,
                                              DateTime start, DateTime end, string web_link, string extended_subject,
                                              string extended_class, string extended_school, string extended_grade,
                                              string event_id, string body_content)
        {
            var ev = _all.GetEvents().FirstOrDefault(a => a.EventId.Equals(event_id));
            if (ev == null)
            {
                ev = new CalenderEvent()
                {
                    BodyContent = body_content,
                    End = end,
                    EventId = event_id,
                    ExtendedClass = extended_class,
                    ExtendedGrade = extended_grade,
                    ExtendedSchool = extended_school,
                    ExtendedSubject = extended_subject,
                    OrganizerEmail = organizer_email,
                    OrganizerName = organizer_name,
                    Start = start,
                    Subject = subject,
                    WebLink = web_link
                };

                _repo.CalenderEvent.Create(ev);
                _repo.Save(ev);
            }
            else
            {
                if (organizer_email.Contains("AFB"))
                {
                    int i = 0;
                }
                ev.BodyContent = body_content;
                ev.End = end;
                ev.ExtendedClass = extended_class;
                ev.ExtendedGrade = extended_grade;
                ev.ExtendedSchool = extended_school;
                ev.ExtendedSubject = extended_subject;
                ev.OrganizerEmail = organizer_email;
                ev.OrganizerName = organizer_name;
                ev.Start = start;
                ev.Subject = subject;
                ev.WebLink = web_link;

                _repo.CalenderEvent.Update(ev);
                _repo.Save(ev);

            }
            return ev;
        }
        #endregion
    }


}
