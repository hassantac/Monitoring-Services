namespace Meetings.Services.Interface
{
    public interface ISubjectClassService
    {
        bool AddSubjectClass(long subject_id, long class_id);
        bool RemoveSubjectClass(long id);
    }
}
