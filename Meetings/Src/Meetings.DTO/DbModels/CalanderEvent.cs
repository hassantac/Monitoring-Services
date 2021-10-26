using System;
using System.Collections.Generic;

namespace Meetings.DTO.DbModels
{
    public class CalenderEvent
    {
        public CalenderEvent()
        {
            UserEvents = new HashSet<UserEvent>();
        }

        public long Id { get; set; }
        public string Subject { get; set; }
        public string OrganizerEmail { get; set; }
        public string OrganizerName { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string WebLink { get; set; }
        public string ExtendedSubject { get; set; }
        public string ExtendedClass { get; set; }
        public string ExtendedSchool { get; set; }
        public string ExtendedGrade { get; set; }
        public string EventId { get; set; }
        public string BodyContent { get; set; }
        public virtual ICollection<UserEvent> UserEvents { get; set; }
    }
}