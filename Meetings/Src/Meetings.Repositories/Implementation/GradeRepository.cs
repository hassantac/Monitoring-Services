using Meetings.DTO.DbModels;
using Meetings.EF;
using Meetings.Repositories.Implementation.Base;
using Meetings.Repositories.Interface;

namespace Meetings.Repositories.Implementation
{
    internal class GradeRepository : RepositoryBase<Grade>, IGradeRepository
    {
        public GradeRepository(MeetingsContext db) : base(db)
        {

        }
    }
}