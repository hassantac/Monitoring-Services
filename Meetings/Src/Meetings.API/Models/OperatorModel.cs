using System.Text.Json.Serialization;

namespace Meetings.API.Models
{
    #region Request
    public class AddOperatorRequest
    {
        [JsonPropertyName("opertor_id")]
        public long Operator_Id { get; set; }
        [JsonPropertyName("opertor_name")]
        public string OperatorName { get; set; }
    }
    #endregion

    #region Response
    public class OperatorResponse
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }
        [JsonPropertyName("opertor_id")]
        public long Operator_Id { get; set; }
        [JsonPropertyName("opertor_name")]
        public string OperatorName { get; set; }
    }
    #endregion

    #region Query

    #endregion
}
