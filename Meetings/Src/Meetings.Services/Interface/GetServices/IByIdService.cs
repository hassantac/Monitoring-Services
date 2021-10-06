using Meetings.DTO.DbModels;

namespace Meetings.Services.Interface.GetServices
{
    public interface IByIdService
    {
        bool AnyUser(long id);
        User GetUser(long id);

        bool AnyClassOfSchool(long id);
        ClassOfSchool GetClassOfSchool(long id);


        bool AnyGrade(long id);
        Grade GetGrade(long id);

        bool AnyOperator(long id);
        Operator GetOperator(long id);


        bool AnySchool(long id);
        School GetSchool(long id);

        bool AnySchoolGrade(long id);
        SchoolGrade GetSchoolGrade(long id);

        bool AnySubject(long id);
        Subject GetSubject(long id);


        bool AnySubjectClass(long id);
        SubjectClass GetSubjectClass(long id);


        UserEvent GetUserEvent(long id);


        CalenderEvent GetEvent(long id);
        bool AnyEvent(long id);
    }
}
