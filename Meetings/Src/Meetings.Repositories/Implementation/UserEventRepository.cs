using Meetings.DTO.DbModels;
using Meetings.EF;
using Meetings.Repositories.Implementation.Base;
using Meetings.Repositories.Interface;

namespace Meetings.Repositories.Implementation
{
    internal class UserEventRepository : RepositoryBase<UserEvent>, IUserEventRepository
    {
        public UserEventRepository(MeetingsContext db) : base(db)
        {

        }
    }
}