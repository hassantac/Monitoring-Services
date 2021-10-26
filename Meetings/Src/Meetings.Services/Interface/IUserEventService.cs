namespace Meetings.Services.Interface
{
    public interface IUserEventService
    {
        bool AddUserEvent(long event_id, long user_id);

        bool RemoveUserEvent(long id);
    }
}