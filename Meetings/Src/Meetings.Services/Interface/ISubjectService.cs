using Meetings.DTO.DbModels;

namespace Meetings.Services.Interface
{
    public interface ISubjectService
    {
        Subject AddSubject(long subject_id, string name);
        bool EditSubject(long id, long subject_id, string name);
        bool RemoveSubject(long id);
    }
}
