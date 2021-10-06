using Meetings.DTO.DbModels;
using Meetings.EF;
using Meetings.Repositories.Implementation.Base;
using Meetings.Repositories.Interface;

namespace Meetings.Repositories.Implementation
{
    internal class ClassOfSchoolRepository : RepositoryBase<ClassOfSchool>, IClassOfSchoolRepository
    {
        public ClassOfSchoolRepository(MeetingsContext db) : base(db)
        {

        }
    }
}