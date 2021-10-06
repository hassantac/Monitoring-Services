using Meetings.DTO.DbModels;
using Meetings.EF;
using Meetings.Repositories.Implementation.Base;
using Meetings.Repositories.Interface;

namespace Meetings.Repositories.Implementation
{
    internal class SchoolRepository : RepositoryBase<School>, ISchoolRepository
    {
        public SchoolRepository(MeetingsContext db) : base(db)
        {

        }
    }
}