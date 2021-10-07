using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Meetings.API.Models
{
    #region Request
    public class AddClassOfSchoolRequest
    {
        [JsonPropertyName("class_name")]
        public string ClassName { get; set; }
        [JsonPropertyName("school_grade_id")]
        public long SchoolGrade_Id { get; set; }
        [JsonPropertyName("subjects")]
        public List<long> Subjects { get; set; }
    }
    #endregion

    #region Response
    public class ClassOfSchoolResponse
    {
        [JsonPropertyName("class_name")]
        public string ClassName { get; set; }
        [JsonPropertyName("id")]
        public long Id { get; set; }
    }
    #endregion

    #region Query

    #endregion

}
