using Meetings.DTO.DbModels;
using Meetings.EF;
using Meetings.Repositories.Implementation.Base;
using Meetings.Repositories.Interface;

namespace Meetings.Repositories.Implementation
{
    internal class CalenderEventRepository : RepositoryBase<CalenderEvent>, ICalenderEventRepository
    {
        public CalenderEventRepository(MeetingsContext db) : base(db)
        {
        }
    }
}