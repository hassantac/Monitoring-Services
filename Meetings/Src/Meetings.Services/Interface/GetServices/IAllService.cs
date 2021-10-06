using Meetings.DTO.DbModels;
using System.Linq;

namespace Meetings.Services.Interface.GetServices
{
    public interface IAllService
    {
        IQueryable<User> GetUsers();
        IQueryable<ClassOfSchool> GetClassesOfSchool();
        IQueryable<Grade> GetGrades();
        IQueryable<Operator> GetOperators();
        IQueryable<School> GetSchools();
        IQueryable<SchoolGrade> GetSchoolGrades();
        IQueryable<Subject> GetSubjects();
        IQueryable<SubjectClass> GetSubjectClasses();
        IQueryable<CalenderEvent> GetEvents();
        IQueryable<UserEvent> GetUserEvents();
    }
}
