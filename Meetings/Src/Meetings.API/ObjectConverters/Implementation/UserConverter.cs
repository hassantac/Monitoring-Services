using Meetings.API.Models;
using Meetings.API.ObjectConverters.Interface;
using Meetings.API.Utils.Request;
using Meetings.Common.JWT;
using Meetings.DTO.DbModels;
using Meetings.Services.Interface.Unit;
using Microsoft.AspNetCore.Http;

namespace Meetings.API.ObjectConverters.Implementation
{
    internal class UserConverter : IUserConverter
    {
        #region Private Fields
        private readonly IServiceUnit _service;
        #endregion


        #region Private Methods

        #endregion


        #region Constructors
        public UserConverter(IServiceUnit service)
        {
            _service = service;
        }
        #endregion


        #region Properties

        #endregion


        #region Fields

        #endregion


        #region Methods
        public TokenModel GetAdminToken(HttpContext context)
        {
            var request = context.Request;
            var authToken = RequestHelper.GetAuthorizationTokenHeaderValue(request);
            var tokenValue = authToken.Split(" ");
            var token = TokenManger.ValidateToken(tokenValue[1]);

            return token;
        }

        public UserResponse GetUserResponse(User account)
        {
            var res = new UserResponse()
            {
                AccountType = account.AccountType,
                Id = account.Id,
                Name = account.Name,
                Email = account.Email,
                Username = account.Username,
                User_Id = account.User_Id,
                Password = account.Password
            };
            return res;
        }
        #endregion
    }
}
