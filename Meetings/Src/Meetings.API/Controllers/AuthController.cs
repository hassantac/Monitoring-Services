using Meetings.API.Attributes;
using Meetings.API.Models;
using Meetings.API.Models.Common;
using Meetings.API.ObjectConverters.Interface.Unit;
using Meetings.API.Utils.Messages;
using Meetings.Common.Enums;
using Meetings.Common.Helper;
using Meetings.Common.JWT;
using Meetings.Services.Interface.Unit;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Meetings.API.Controllers
{
    [Route("v1/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        #region Private Fields

        private readonly IServiceUnit _service;
        private readonly IConverterUnit _converter;

        #endregion Private Fields



        #region Constructors

        public AuthController(IServiceUnit service, IConverterUnit converter)
        {
            _service = service;
            _converter = converter;
        }

        #endregion Constructors



        #region Methods

        #region End Points

        #region POST

        [HttpPost]
        [Route("login")]
        public ActionResult<ResponseWrapper<LoginResponse<UserResponse>>> Login(LoginRequest model)
        {
            try
            {
                var account = _service.All.GetUsers().FirstOrDefault(f => f.Password.Equals(model.Password)
                                                                          && (f.Username.Equals(model.Username) || f.Email.Equals(model.Username)));
                if (account == null)
                {
                    return Unauthorized(new ResponseWrapper<object>(false, MessageHelper.InvalidUsernameOrPassword, ApiError.InvalidRequest(), null));
                }

                var jwtToken = TokenManger.GenerateToken(account.Id, AccountType.Admin);

                var token = TokenManger.ValidateToken(jwtToken);

                return Ok(new ResponseWrapper<LoginResponse<UserResponse>>()
                {
                    Data = new LoginResponse<UserResponse>()
                    {
                        Role = AccountType.Admin.ToString(),
                        Token = jwtToken,
                        User = _converter.User.GetUserResponse(account)
                    },
                    Message = MessageHelper.SuccessfullyLogin,
                    Success = true,
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseWrapper<object>(false, ex.Message, ApiError.InvalidRequest(), null));
            }
        }

        #endregion POST

        #region GET

        [HttpGet]
        [Route("current")]
        [CheckJwt(Allows = new[] { AccountType.Admin })]
        public ActionResult<ResponseWrapper<LoginResponse<object>>> GetCurrentUser()
        {
            try
            {
                var token = _converter.User.GetAdminToken(HttpContext);
                var user = _service.ById.GetUser(token.Id);
                return Ok(new ResponseWrapper<LoginResponse<UserResponse>>
                {
                    Success = true,
                    Message = MessageHelper.SuccessfullyGet,
                    Data = new LoginResponse<UserResponse>()
                    {
                        Role = AccountType.Admin.ToString(),
                        User = _converter.User.GetUserResponse(user)
                    }
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseWrapper<object>(false, ex.Message, ApiError.InvalidRequest(), null));
            }
        }

        #endregion GET

        #endregion End Points

        #endregion Methods
    }
}