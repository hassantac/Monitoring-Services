using Meetings.DTO.DbModels;

namespace Meetings.Services.Interface
{
    public interface IClassOfSchoolService
    {
        ClassOfSchool AddClassOfSchool(string class_name, string class_full_name, string short_name, string teams, string nick, long school_grade_id);
        bool RemoveClassOfSchool(long id);
    }
}
