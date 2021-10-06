using Meetings.Services.Interface.GetServices;

namespace Meetings.Services.Interface.Unit
{
    public interface IServiceUnit
    {
        IUserService User { get; }
        IAllService All { get; }
        IByIdService ById { get; }

        IOperatorService Operator { get; }
        ISchoolService School { get; }
        IClassOfSchoolService ClassOfSchool { get; }
        IGradeService Grade { get; }
        ISchoolGradeService SchoolGrade { get; }
        ISubjectService Subject { get; }
        ISubjectClassService SubjectClass { get; }
        IUserEventService UserEvent { get; }
        ICalenderEventService Event { get; }

        void BeginTransaction();
        void CommitTransaction();
        void RollBackTransaction();
    }
}
