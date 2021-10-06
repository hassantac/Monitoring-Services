using Meetings.DTO.DbModels;
using Meetings.EF;
using Meetings.Repositories.Implementation.Base;
using Meetings.Repositories.Interface;

namespace Meetings.Repositories.Implementation
{
    internal class OperatorRepository : RepositoryBase<Operator>, IOperatorRepository
    {
        public OperatorRepository(MeetingsContext db) : base(db)
        {

        }
    }
}