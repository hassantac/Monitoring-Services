using Meetings.DTO.DbModels;
using Meetings.Repositories.Interface.Unit;
using Meetings.Services.Interface.GetServices;
using System.Linq;

namespace Meetings.Services.Implementation.GetServices
{
    internal class ByIdService : IByIdService
    {
        #region Private Fields

        private readonly IRepositoryUnit _repo;
        private readonly IAllService _all;

        #endregion Private Fields



        #region Constructor

        public ByIdService(IRepositoryUnit repo)
        {
            _repo = repo;
            _all = new AllService(_repo);
        }

        #endregion Constructor



        #region Methods

        public bool AnyUser(long id)
        {
            return _all.GetUsers().Any(a => a.Id == id);
        }

        public bool AnyEvent(long id)
        {
            return _all.GetEvents().Any(a => a.Id == id);
        }

        public CalenderEvent GetEvent(long id)
        {
            return _all.GetEvents().FirstOrDefault(a => a.Id == id);
        }

        public UserEvent GetUserEvent(long id)
        {
            return _all.GetUserEvents().FirstOrDefault(a => a.Id == id);
        }

        public User GetUser(long id)
        {
            return _all.GetUsers().FirstOrDefault(a => a.Id == id);
        }

        #endregion Methods
    }
}