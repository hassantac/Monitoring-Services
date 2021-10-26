using Meetings.API.Models.Common;
using Meetings.API.Utils.KeysAndValues;
using Meetings.API.Utils.Messages;
using Meetings.Common.Enums;
using Meetings.Common.Helper;
using Meetings.Common.JWT;
using Meetings.Services.Interface.Unit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Meetings.API.Filters
{
    public class CheckJwtFilter : IAuthorizationFilter
    {
        #region Private Fields

        private readonly IServiceUnit _service;

        #endregion Private Fields



        #region Constructors

        public CheckJwtFilter(IServiceUnit service)
        {
            _service = service;
            Allows = new List<AccountType>();
        }

        #endregion Constructors

        #region Properties

        public List<AccountType> Allows { get; set; }

        #endregion Properties



        #region Methods

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            try
            {
                string authTokenValue;

                if (context.HttpContext.Request.Headers.Keys.Any(a => a.Equals(ApiHeaders.AUTHORIZATION)))
                {
                    authTokenValue = context.HttpContext.Request.Headers[ApiHeaders.AUTHORIZATION];

                    if (string.IsNullOrWhiteSpace(authTokenValue))
                    {
                        context.Result = new BadRequestObjectResult(new ResponseWrapper<object>(false, MessageHelper.HeaderValueMissing("token"), null, null));

                        return;
                    }
                }
                else
                {
                    context.Result = new BadRequestObjectResult(new ResponseWrapper<object>(false, MessageHelper.HeaderMissing("Authorization"), null, null));

                    return;
                }

                var tokenValues = authTokenValue.Split(" ");

                if (tokenValues.Length != 2)
                {
                    context.Result = new BadRequestObjectResult(new ResponseWrapper<object>(false, MessageHelper.InvalidJwtToken, ApiError.InvalidRequest(), null));

                    return;
                }

                var token = TokenManger.ValidateToken(tokenValues[1]);

                if (token == null)
                {
                    context.Result = new BadRequestObjectResult(new ResponseWrapper<object>(false, MessageHelper.InvalidJwtToken, ApiError.InvalidRequest(), null));

                    return;
                }

                var date = DateTime.UtcNow;

                if (token.ExpiresAt < date)
                {
                    context.Result = new UnauthorizedObjectResult(new ResponseWrapper<object>(false, MessageHelper.InvalidJwtToken, ApiError.InvalidRequest(), null));

                    return;
                }

                if (Allows != null && Allows.Any())
                {
                    if (Allows.All(a => a != token.Type))
                    {
                        context.Result = new UnauthorizedObjectResult(new ResponseWrapper<object>(false, MessageHelper.InvalidJwtToken, ApiError.InvalidRequest(), null));

                        return;
                    }
                }

                // Admin
                if (token.Type == AccountType.Admin)
                {
                    if (!_service.ById.AnyUser(token.Id))
                    {
                        context.Result = new UnauthorizedObjectResult(new ResponseWrapper<object>(false, MessageHelper.InvalidJwtToken, ApiError.InvalidRequest(), null));

                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                context.Result = new BadRequestObjectResult(new ResponseWrapper<object>(false, ex.Message, ApiError.InvalidRequest(), null));
            }
        }

        #endregion Methods
    }
}