namespace Meetings.Services.Interface
{
    public interface IGradeService
    {
        bool AddGrade(long grade_id, string name);
        bool EditGrade(long id, long grade_id, string name);
        bool RemoveGrade(long id);
    }
}
