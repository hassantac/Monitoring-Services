using Meetings.DTO.DbModels;
using Meetings.EF;
using Meetings.Repositories.Implementation.Base;
using Meetings.Repositories.Interface;

namespace Meetings.Repositories.Implementation
{
    internal class SchoolGradeRepository : RepositoryBase<SchoolGrade>, ISchoolGradeRepository
    {
        public SchoolGradeRepository(MeetingsContext db) : base(db)
        {

        }
    }
}