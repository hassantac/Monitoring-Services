using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Meetings.API.Models.Common
{
    #region Request

    public class LoginRequest
    {
        [JsonPropertyName("username")]
        [Required]
        public string Username { get; set; }

        [JsonPropertyName("password")]
        [Required]
        public string Password { get; set; }
    }

    public class UpdatePasswordRequest
    {
        [JsonPropertyName("old_password")]
        [Required]
        public string OldPassword { get; set; }

        [JsonPropertyName("password")]
        [Required]
        public string Password { get; set; }
    }

    #endregion Request

    #region Response

    public class PagedResponse<TData> : ResponseWrapper<TData>
    {
        #region Constructors

        public PagedResponse()
        {
        }

        public PagedResponse(TData data, int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            Data = data;
            Message = null;
            Success = true;
            Error = null;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Index: 0
        /// Type: Response
        /// Description: Page Number
        /// </summary>
        [JsonPropertyName("page_number")]
        public int PageNumber { get; set; }

        /// <summary>
        /// Index: 1
        /// Type: Response
        /// Description: Page size
        /// </summary>
        [JsonPropertyName("page_size")]
        public int PageSize { get; set; }

        /// <summary>
        /// Index: 2
        /// Type: Response
        /// Description: Total Pages
        /// </summary>
        [JsonPropertyName("total_pages")]
        public int TotalPages { get; set; }

        /// <summary>
        /// Index: 3
        /// Type: Response
        /// Description: Total table records
        /// </summary>
        [JsonPropertyName("total_records")]
        public int TotalRecords { get; set; }

        #endregion Properties
    }

    public class PagedResponse<TData, F> : ResponseWrapper<TData>
    {
        #region Constructors

        public PagedResponse()
        {
        }

        public PagedResponse(F Filter, TData data, int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            Data = data;
            Message = null;
            Success = true;
            Error = null;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Index: 0
        /// Type: Response
        /// Description: Page Number
        /// </summary>
        [JsonPropertyName("page_number")]
        public int PageNumber { get; set; }

        /// <summary>
        /// Index: 1
        /// Type: Response
        /// Description: Page size
        /// </summary>
        [JsonPropertyName("page_size")]
        public int PageSize { get; set; }

        /// <summary>
        /// Index: 2
        /// Type: Response
        /// Description: Total Pages
        /// </summary>
        [JsonPropertyName("total_pages")]
        public int TotalPages { get; set; }

        /// <summary>
        /// Index: 3
        /// Type: Response
        /// Description: Total table records
        /// </summary>
        [JsonPropertyName("total_records")]
        public int TotalRecords { get; set; }

        /// <summary>
        /// Index: 4
        /// Type: Filter
        /// Description: Filter
        /// </summary>
        [JsonPropertyName("filter")]
        public F Filter { get; set; }

        #endregion Properties
    }

    public class ErrorResponse
    {
        #region Constructors

        public ErrorResponse()
        {
        }

        public ErrorResponse(string message)
        {
            this.ErrorCode = null;
            this.ErrorMessage = message;
        }

        public ErrorResponse(int code)
        {
            this.ErrorCode = code;
            this.ErrorMessage = ErrorMessage;
        }

        public ErrorResponse(int code, string message)
        {
            this.ErrorCode = code;
            this.ErrorMessage = message;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Index: 0
        /// Type: Response
        /// Description: Error code from the api
        /// </summary>
        [JsonPropertyName("error_code")]
        public int? ErrorCode { get; set; }

        /// <summary>
        /// Index: 1
        /// Type: Response
        /// Description: Error message from the api
        /// </summary>
        [JsonPropertyName("error_message")]
        public string ErrorMessage { get; set; }

        #endregion Properties
    }

    public class LoginResponse<TData>
    {
        [JsonPropertyName("token")]
        public string Token { get; set; }

        [JsonPropertyName("token_type")]
        public string TokenType { get; set; } = "bearer";

        public TData User { get; set; }

        public string Role { get; set; }
    }

    public class ResponseWrapper<TData>
    {
        #region Constructors

        public ResponseWrapper()
        {
        }

        public ResponseWrapper(bool success, string message, ErrorResponse error, TData data)
        {
            this.Success = success;
            this.Message = message;
            this.Error = error;
            this.Data = data;
        }

        #endregion Constructors

        #region Properties

        /// <summary>
        /// Index: 0
        /// Type: Response
        /// Description: State is Api request is success of not
        /// </summary>
        [JsonPropertyName("success")]
        public bool Success { get; set; }

        /// <summary>
        /// Index: 1
        /// Type: Response
        /// Description: Message from api request
        /// </summary>
        [JsonPropertyName("message")]
        public string Message { get; set; }

        /// <summary>
        /// Index: 2
        /// Type: Response
        /// Description: Error from the api request
        /// </summary>
        [JsonPropertyName("error")]
        public ErrorResponse Error { get; set; }

        /// <summary>
        /// Index: 3
        /// Type: Response
        /// Description: Api response data
        /// </summary>
        [JsonPropertyName("data")]
        public TData Data { get; set; }

        #endregion Properties
    }

    public class IdAndName
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }
    }

    #endregion Response
}