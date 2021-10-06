using Meetings.DTO.DbModels;
using System;

namespace Meetings.Services.Interface
{
    public interface ICalenderEventService
    {
        CalenderEvent AddCalenderEvent(string subject, string organizer_email, string organizer_name, DateTime start,
                                       DateTime end, string web_link, string extended_subject, string extended_class,
                                       string extended_school, string extended_grade, string event_id, string body_content);
    }
}
