using Meetings.DTO.DbModels;
using Meetings.Repositories.Interface.Unit;
using Meetings.Services.Interface.GetServices;
using System.Linq;

namespace Meetings.Services.Implementation.GetServices
{
    internal class AllService : IAllService
    {
        #region Private Fields

        private readonly IRepositoryUnit _repo;

        #endregion Private Fields



        #region Constructor

        public AllService(IRepositoryUnit repo)
        {
            _repo = repo;
        }

        #endregion Constructor



        #region Methods

        public IQueryable<User> GetUsers()
        {
            return _repo.User.FindByCondition(f => !f.IsDeleted);
        }

        public IQueryable<UserEvent> GetUserEvents()
        {
            return _repo.UserEvent.FindAll();
        }

        public IQueryable<CalenderEvent> GetEvents()
        {
            return _repo.CalenderEvent.FindAll();
        }

        #endregion Methods
    }
}