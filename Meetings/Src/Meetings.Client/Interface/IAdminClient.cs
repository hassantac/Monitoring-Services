using Meetings.Client.Models;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace Meetings.Client.Interface
{
    public interface IAdminClient
    {
        List<OperatorResponse> GetOperators();
        List<SchoolResponse> GetSchools(int? form);
        List<string> GetGrades(int? operator_id, string school);
        List<ClassOfSchoolResponse> GetClasses(int? operator_id, string school, string grade);
        ClassSmallResponse GetClasses(string nick_name);
        List<SubjectResponse> GetSubjects(int? operator_id, string school, string grade);

    }
}
