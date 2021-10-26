using Meetings.DTO.DbModels;
using System.Linq;

namespace Meetings.Services.Interface.GetServices
{
    public interface IAllService
    {
        IQueryable<User> GetUsers();

        IQueryable<CalenderEvent> GetEvents();

        IQueryable<UserEvent> GetUserEvents();
    }
}