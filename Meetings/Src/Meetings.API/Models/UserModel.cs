using Meetings.Common.Enums;
using System.Text.Json.Serialization;

namespace Meetings.API.Models
{
    #region Response

    public class UserResponse
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("first_name")]
        public string Name { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("username")]
        public string Username { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }

        [JsonPropertyName("account_type")]
        public AccountType AccountType { get; set; }

        [JsonPropertyName("user_id")]
        public string User_Id { get; set; }
    }

    #endregion Response
}