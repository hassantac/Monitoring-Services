using System.Text.Json.Serialization;

namespace Meetings.API.Models
{
    #region Request

    public class AddGradeRequest
    {
        [JsonPropertyName("grade_id")]
        public long Grade_Id { get; set; }

        [JsonPropertyName("grade_name")]
        public string GradeName { get; set; }
    }

    #endregion Request

    #region Response

    public class GradeResponse
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("grade_name")]
        public string GradeName { get; set; }
    }

    #endregion Response
}