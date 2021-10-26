using Meetings.API.Models.Common;
using Meetings.Common.Helper;

namespace Meetings.API.Utils.Messages
{
    internal static class ApiError
    {
        #region Methods

        public static ErrorResponse InvalidRequest()
        {
            int code = (int)ApiErrorCode.INVALID_REQUEST;
            string message = "Bad Request";
            var error = new ErrorResponse(code, message);

            return error;
        }

        public static ErrorResponse NotFound()
        {
            int code = (int)ApiErrorCode.NOT_FOUND;
            string message = "Not Found!";
            var error = new ErrorResponse(code, message);

            return error;
        }

        public static ErrorResponse MissingBody()
        {
            int code = (int)ApiErrorCode.MISSING_BODY;
            string message = MessageHelper.BodyNotPresent;
            var error = new ErrorResponse(code, message);

            return error;
        }

        public static ErrorResponse InvalidUser()
        {
            int code = (int)ApiErrorCode.INVALID_USER;
            string message = MessageHelper.UserNotFound;
            var error = new ErrorResponse(code, message);

            return error;
        }

        public static ErrorResponse NotAllowToAccess()
        {
            int code = (int)ApiErrorCode.NOT_ALLOW_TO_ACCESS;
            string message = MessageHelper.NotAllowToAccessTheRoute;
            var error = new ErrorResponse(code, message);

            return error;
        }

        public static ErrorResponse NotAllowToAccessData()
        {
            int code = (int)ApiErrorCode.NOT_ALLOW_TO_ACCESS_DATA;
            string message = MessageHelper.NotAllowToAccessTheData;
            var error = new ErrorResponse(code, message);

            return error;
        }

        #endregion Methods
    }
}