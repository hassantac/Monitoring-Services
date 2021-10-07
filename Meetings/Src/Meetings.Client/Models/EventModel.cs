using Microsoft.Graph;

namespace Meetings.Client.Models
{
    public class ClassesList
    {
        public string NickName { get; set; }
        public string ExtendedClass { get; set; }
        public string ExtendedSchool { get; set; }
        public string ExtendedGrade { get; set; }
    }
    public class ExtendedEvent
    {
        public string Subject { get; set; }
        public Recipient Organizer { get; set; }
        public DateTimeTimeZone Start { get; set; }
        public DateTimeTimeZone End { get; set; }
        public string WebLink { get; set; }
        public string ExtendedSubject { get; set; }
        public string ExtendedClass { get; set; }
        public string ExtendedSchool { get; set; }
        public string ExtendedGrade { get; set; }
        public string EventId { get; set; }
        public string BodyContent { get; set; }


    }
}
