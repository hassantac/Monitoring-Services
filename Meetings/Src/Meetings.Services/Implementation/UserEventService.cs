using Meetings.Common.Helper;
using Meetings.DTO.DbModels;
using Meetings.Repositories.Interface.Unit;
using Meetings.Services.Implementation.GetServices;
using Meetings.Services.Interface;
using Meetings.Services.Interface.GetServices;
using System;
using System.Linq;

namespace Meetings.Services.Implementation
{
    internal class UserEventService : IUserEventService
    {
        #region Private Fields

        private readonly IRepositoryUnit _repo;
        private readonly IAllService _all;
        private readonly IByIdService _byId;

        #endregion Private Fields



        #region Constructor

        public UserEventService(IRepositoryUnit repo)
        {
            _repo = repo;
            _all = new AllService(_repo);
            _byId = new ByIdService(_repo);
        }

        #endregion Constructor



        #region Methods

        public bool AddUserEvent(long event_id, long user_id)
        {
            if (!_byId.AnyEvent(event_id))
                throw new Exception(MessageHelper.NotFound("Event"));

            if (!_byId.AnyUser(user_id))
                throw new Exception(MessageHelper.NotFound("User"));

            var userEvent = _all.GetUserEvents().FirstOrDefault(f => f.User_Id == user_id && event_id == f.Event_Id);
            if (userEvent == null)
            {
                userEvent = new UserEvent()
                {
                    Event_Id = event_id,
                    User_Id = user_id
                };

                _repo.UserEvent.Create(userEvent);
                _repo.Save(userEvent);
            }
            return true;
        }

        public bool RemoveUserEvent(long id)
        {
            var UserEvent = _byId.GetUserEvent(id);
            if (UserEvent == null)
                throw new Exception(MessageHelper.NotFound("User Event"));

            _repo.UserEvent.Delete(UserEvent);
            _repo.Save(UserEvent);

            return true;
        }

        #endregion Methods
    }
}