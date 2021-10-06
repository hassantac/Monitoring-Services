using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Meetings.API.Models
{
    public class CalenderEventResponse
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }
        [JsonPropertyName("subject")]
        public string Subject { get; set; }
        [JsonPropertyName("organizar_email")]
        public string OrganizerEmail { get; set; }
        [JsonPropertyName("organizar_name")]
        public string OrganizerName { get; set; }
        [JsonPropertyName("start")]
        public DateTime Start { get; set; }
        [JsonPropertyName("end")]
        public DateTime End { get; set; }
        [JsonPropertyName("web_link")]
        public string WebLink { get; set; }
        [JsonPropertyName("extended_subject")]
        public string ExtendedSubject { get; set; }
        [JsonPropertyName("extended_class")]
        public string ExtendedClass { get; set; }
        [JsonPropertyName("extended_school")]
        public string ExtendedSchool { get; set; }
        [JsonPropertyName("extended_grade")]
        public string ExtendedGrade { get; set; }
        [JsonPropertyName("event_id")]
        public string EventId { get; set; }
        [JsonPropertyName("body_content")]
        public string BodyContent { get; set; }
    }
}
