using Meetings.API.Models;
using Meetings.Common.JWT;
using Meetings.DTO.DbModels;
using Microsoft.AspNetCore.Http;

namespace Meetings.API.ObjectConverters.Interface
{
    public interface IUserConverter
    {
        TokenModel GetAdminToken(HttpContext context);

        UserResponse GetUserResponse(User account);
    }
}