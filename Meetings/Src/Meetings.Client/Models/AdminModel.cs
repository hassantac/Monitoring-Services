using System.Text.Json.Serialization;

namespace Meetings.Client.Models
{
    #region Request
    public class NicknameRequest
    {
        public string Nickname { get; set; }
    }

    public class GetSchoolModel
    {
        public int? Operator_Id { get; set; }
    }
    public class GradeQueryModel : GetSchoolModel
    {
        public string School { get; set; }
    }
    public class ClassOfSchoolQueryModel : GradeQueryModel
    {
        public string Grade { get; set; }
    }
    #endregion

    #region Request
    public class OperatorResponse
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [JsonPropertyName("Name")]
        public string Name { get; set; }
    }
    public class SubjectResponse
    {
        [JsonPropertyName("SubjectId")]
        public int SubjectId { get; set; }

        [JsonPropertyName("SubjectName")]
        public string SubjectName { get; set; }
    }

    public class ClassOfSchoolResponse
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [JsonPropertyName("ClassName")]
        public string ClassName { get; set; }
    }


    public class ClassSmallResponse
    {
        [JsonPropertyName("ClassName")]
        public string ClassName { get; set; }
        [JsonPropertyName("School")]
        public string School { get; set; }
        [JsonPropertyName("Grade")]
        public string Grade { get; set; }
    }

    public class SchoolResponse
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [JsonPropertyName("Name")]
        public string Name { get; set; }

        [JsonPropertyName("Abbreviation")]
        public string Abbreviation { get; set; }
    }
    #endregion
}
