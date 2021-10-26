using Meetings.DTO.DbModels;

namespace Meetings.Services.Interface.GetServices
{
    public interface IByIdService
    {
        bool AnyUser(long id);

        User GetUser(long id);

        UserEvent GetUserEvent(long id);

        CalenderEvent GetEvent(long id);

        bool AnyEvent(long id);
    }
}