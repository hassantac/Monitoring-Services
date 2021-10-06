using Meetings.DTO.DbModels;
using Meetings.EF;
using Meetings.Repositories.Implementation.Base;
using Meetings.Repositories.Interface;

namespace Meetings.Repositories.Implementation
{

    internal class SubjectClassRepository : RepositoryBase<SubjectClass>, ISubjectClassRepository
    {
        public SubjectClassRepository(MeetingsContext db) : base(db)
        {

        }
    }
}