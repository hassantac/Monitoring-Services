using System.Text.Json.Serialization;

namespace Meetings.API.Models
{
    #region Request

    public class AddSubjectRequest
    {
        [JsonPropertyName("subject_id")]
        public long Subject_Id { get; set; }

        [JsonPropertyName("subject_name")]
        public string SubjectName { get; set; }
    }

    #endregion Request

    #region Response

    public class SubjectResponse
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("subject_name")]
        public string SubjectName { get; set; }
    }

    #endregion Response
}