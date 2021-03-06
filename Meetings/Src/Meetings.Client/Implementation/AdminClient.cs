using Meetings.Client.Interface;
using Meetings.Client.Models;
using Meetings.Common.Helper;
using System.Collections.Generic;
using System.Text.Json;

namespace Meetings.Client.Implementation
{
    internal class AdminClient : IAdminClient
    {
        #region Methods

        public List<OperatorResponse> GetOperators()
        {
            var baseURL = AppSettingHelper.GetAdminURL();
            string response = HttpCaller.GetRequest($"{baseURL}/v1/operator");
            return JsonSerializer.Deserialize<List<OperatorResponse>>(response);
        }

        public List<SchoolResponse> GetSchools(int? operator_id)
        {
            var schoolQuery = new GetSchoolModel()
            {
                Operator_Id = operator_id
            };
            var formObject = JsonSerializer.Serialize(schoolQuery);

            var baseURL = AppSettingHelper.GetAdminURL();
            var response = HttpCaller.PostString($"{baseURL}/v1/school", formObject);

            return JsonSerializer.Deserialize<List<SchoolResponse>>(response);
        }

        public List<string> GetGrades(int? operator_id, string school)
        {
            var gradeQuery = new GradeQueryModel()
            {
                Operator_Id = operator_id,
                School = school
            };
            var formObject = JsonSerializer.Serialize(gradeQuery);

            var baseURL = AppSettingHelper.GetAdminURL();
            var response = HttpCaller.PostString($"{baseURL}/v1/grade", formObject);

            return JsonSerializer.Deserialize<List<string>>(response);
        }

        public List<ClassOfSchoolResponse> GetClasses(int? operator_id, string school, string grade)
        {
            var gradeQuery = new ClassOfSchoolQueryModel()
            {
                Operator_Id = operator_id,
                School = school,
                Grade = grade
            };
            var formObject = JsonSerializer.Serialize(gradeQuery);

            var baseURL = AppSettingHelper.GetAdminURL();
            var response = HttpCaller.PostString($"{baseURL}/v1/class_of_school", formObject);

            return JsonSerializer.Deserialize<List<ClassOfSchoolResponse>>(response);
        }

        public string GetSubjectName(int id)
        {
            var baseURL = AppSettingHelper.GetAdminURL();
            return HttpCaller.GetRequest($"{baseURL}/v1/subject/{id}");
        }

        public List<SubjectResponse> GetSubjects(int? operator_id, string school, string grade)
        {
            var gradeQuery = new ClassOfSchoolQueryModel()
            {
                Operator_Id = operator_id,
                School = school,
                Grade = grade
            };
            var formObject = JsonSerializer.Serialize(gradeQuery);

            var baseURL = AppSettingHelper.GetAdminURL();
            var response = HttpCaller.PostString($"{baseURL}/v1/subject", formObject);

            return JsonSerializer.Deserialize<List<SubjectResponse>>(response);
        }

        public ClassSmallResponse GetClasses((string address, string name) p)
        {
            var model = new NicknameRequest()
            {
                Name = p.name,
                Email = p.address
            };

            var formObject = JsonSerializer.Serialize(model);

            var baseURL = AppSettingHelper.GetAdminURL();
            var response = HttpCaller.PostString($"{baseURL}/v1/class_of_school/nick_name", formObject);

            return JsonSerializer.Deserialize<ClassSmallResponse>(response);
        }

        public List<string> GetSchoolsOfOperators(long operator_id)
        {
            var baseURL = AppSettingHelper.GetAdminURL();
            var response = HttpCaller.GetRequest($"{baseURL}/v1/schools/{operator_id}");

            return JsonSerializer.Deserialize<List<string>>(response);
        }

        #endregion Methods
    }
}