using Meetings.DTO.DbModels;
using Meetings.EF;
using Meetings.Repositories.Implementation.Base;
using Meetings.Repositories.Interface;

namespace Meetings.Repositories.Implementation
{
    internal class SubjectRepository : RepositoryBase<Subject>, ISubjectRepository
    {
        public SubjectRepository(MeetingsContext db) : base(db)
        {

        }
    }
}