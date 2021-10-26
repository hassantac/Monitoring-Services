using Meetings.Common.Enums;

namespace Meetings.Services.Interface
{
    public interface IUserService
    {
        bool AddUser(string email, string username, string password, AccountType account, string name);

        bool AddUserId(long id, string user_id);
    }
}