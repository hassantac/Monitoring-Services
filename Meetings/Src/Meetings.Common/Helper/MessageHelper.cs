namespace Meetings.Common.Helper
{
    public static class MessageHelper
    {
        #region Fields

        public const string UserNotFound = "User not found";

        public static readonly string InvalidBody = "Invalid Request Body";

        public const string InvalidPortalKey = "Invalid portal key";

        public const string IsNotANumber = "Is not a number";

        public const string InvalidApiToken = "Invalid api token";

        public const string InvalidJwtToken = "Invalid jwt token";

        public const string InvalidSignature = "Invalid signature";

        public const string AccountNotFound = "Account not found";

        public const string DataNotFound = "Data not found";

        public const string BodyNotPresent = "Request body not present";

        public const string InvalidEmail = "Invalid email";

        public const string AlreadyHaveEmail = "Email already exist";

        public const string AlreadyHaveUsername = "Username already exist";

        public const string AlreadyHaveName = "Name already exist";

        public const string AlreadyHaveHexCode = "Hex Code already exist";

        public const string AlreadyHaveHandle = "Handle already exist";

        public const string AlreadyHavePhoneNumber = "Phone Number already exist";

        public const string PasswordMissing = "Password missing";

        public const string SuccessfullyAdded = "Data successfully added";

        public const string SuccessfullyUpdated = "Data successfully update";

        public const string SuccessfullyGet = "Data successfully get";

        public const string SuccessfullyDeleted = "Data successfully deleted";

        public const string SuccessfullySend = "Successfully send";

        public const string NotAllowToAccessTheRoute = "Not Allows to access the route";

        public const string NotAllow = "Not allow to access";

        public const string NotAllowToAccessTheData = "User Not Allows to access the data";

        public const string InvalidUsernameOrPassword = "Invalid username or password";

        public const string AccountNotVerified = "Account not verified";

        public const string InvalidFileContent = "Invalid file content";

        public const string SuccessfullyLogin = "Successfully login";

        public const string SuccessfullyLogout = "Successfully logout";

        public const string SuccessfullyVerified = "Successfully verified";

        public const string TypeAlreadyExist = "Type already exist";

        #endregion Fields

        #region Methods

        public static string Invalid(string value)
        {
            return $"Invalid {value}";
        }

        public static string AlreadyExist(string value)
        {
            return $"{value} already exist";
        }

        public static string HeaderMissing(string value)
        {
            return $"The header {value} is missing.";
        }

        public static string HeaderValueMissing(string value)
        {
            return $"The header {value} value is missing.";
        }

        public static string HasEmail(string value)
        {
            return $"The email address {value} already exist";
        }

        public static string HasUserName(string value)
        {
            return $"The username {value} already exist";
        }

        public static string HasHandle(string value)
        {
            return $"The handle {value} already exist";
        }

        public static string HasPhoneNumber(string value)
        {
            return $"The phone number {value} already exist";
        }

        public static string FieldIsRequired(string value)
        {
            return $"{value} is required";
        }

        public static string AppSettingMissing(string value)
        {
            return $"{value} app setting missing";
        }

        public static string NotFound(string value)
        {
            return $"{value} not found.";
        }

        #endregion Methods
    }
}