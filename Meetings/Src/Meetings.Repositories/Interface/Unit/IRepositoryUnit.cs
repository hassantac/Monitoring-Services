namespace Meetings.Repositories.Interface.Unit
{
    public interface IRepositoryUnit
    {
        IUserRepository User { get; }
        IOperatorRepository Operator { get; }
        ISchoolRepository School { get; }
        IClassOfSchoolRepository ClassOfSchool { get; }
        IGradeRepository Grade { get; }
        ISchoolGradeRepository SchoolGrade { get; }
        ISubjectRepository Subject { get; }
        ISubjectClassRepository SubjectClass { get; }
        ICalenderEventRepository CalenderEvent { get; }
        IUserEventRepository UserEvent { get; }

        void Save();
        void Save<TEntity>(TEntity entity);
        void BeginTransaction();
        void CommitTransaction();
        void RollBackTransaction();
    }
}
