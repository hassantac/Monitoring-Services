using Meetings.Common.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Meetings.API.Models
{
    #region Request
    public class AddSchoolRequest
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonPropertyName("address")]
        public string Address { get; set; }

        [JsonPropertyName("contact_us")]
        public string ContactUs { get; set; }

        [JsonPropertyName("principal_name")]
        public string PrincipalName { get; set; }

        [JsonPropertyName("school_type")]
        public SchoolType SchoolType { get; set; }

        [JsonPropertyName("contact_number")]
        public string ContactNumber { get; set; }

        [JsonPropertyName("principal")]
        public string Principal { get; set; }

        [JsonPropertyName("emirate")]
        public string Emirate { get; set; }

        [JsonPropertyName("abbreviaton")]
        public string Abbreviaton { get; set; }

        [JsonPropertyName("operator_id")]
        public long Operator_Id { get; set; }

        [JsonPropertyName("grades")]
        [Required(ErrorMessage = "Grades are required")]
        public List<long> Grades { get; set; }

    }

    #endregion

    #region Response
    public class SchoolResponse
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonPropertyName("address")]
        public string Address { get; set; }

        [JsonPropertyName("contact_us")]
        public string ContactUs { get; set; }

        [JsonPropertyName("principa_name")]
        public string PrincipalName { get; set; }

        [JsonPropertyName("school_type")]
        public SchoolType SchoolType { get; set; }

        [JsonPropertyName("contact_number")]
        public string ContactNumber { get; set; }

        [JsonPropertyName("principal")]
        public string Principal { get; set; }

        [JsonPropertyName("emirate")]
        public string Emirate { get; set; }

        [JsonPropertyName("abbreviaton")]
        public string Abbreviaton { get; set; }

        [JsonPropertyName("operator_id")]
        public long Operator_Id { get; set; }

        [JsonPropertyName("operator")]
        public string Operator { get; set; }

    }
    #endregion

    #region Query

    #endregion
}
