using Meetings.DTO.DbModels;
using Meetings.EF;
using Meetings.Repositories.Implementation.Base;
using Meetings.Repositories.Interface;

namespace Meetings.Repositories.Implementation
{
    internal class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(MeetingsContext db) : base(db)
        {
        }
    }
}