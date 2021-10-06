using Meetings.Common.Enums;
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
    internal class UserService : IUserService
    {
        #region Private Fields
        private readonly IRepositoryUnit _repo;
        private readonly IAllService _all;
        private readonly IByIdService _byId;
        #endregion

        #region Private Methods

        #endregion

        #region Constructor
        public UserService(IRepositoryUnit repo)
        {
            _repo = repo;
            _all = new AllService(_repo);
            _byId = new ByIdService(_repo);
        }


        #endregion

        #region Properties

        #endregion

        #region Fields

        #endregion

        #region Methods
        public bool AddUser(string email, string username, string password, AccountType account, string name)
        {
            if (_all.GetUsers().Any(a => a.Username.Equals(username)))
                throw new Exception(MessageHelper.AlreadyHaveUsername);
            if (_all.GetUsers().Any(a => a.Username.Equals(username)))
                throw new Exception(MessageHelper.AlreadyHaveEmail);

            var user = new User()
            {
                Email = email,
                Name = name,
                Password = password,
                Username = username
            };
            _repo.User.Create(user);
            _repo.Save();

            return true;
        }

        public bool AddUserId(long id, string user_id)
        {
            var user = _byId.GetUser(id);
            if (user == null)
                throw new Exception(MessageHelper.NotFound("user"));

            user.User_Id = user_id;

            _repo.User.Update(user);
            _repo.Save();

            return true;
        }
        #endregion
    }
}
