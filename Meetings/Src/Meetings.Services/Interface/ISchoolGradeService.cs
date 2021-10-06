namespace Meetings.Services.Interface
{
    public interface ISchoolGradeService
    {
        bool AddSchoolGrade(long school_id, long grade_id);
        bool RemoveSchoolGrade(long id);
    }
}
