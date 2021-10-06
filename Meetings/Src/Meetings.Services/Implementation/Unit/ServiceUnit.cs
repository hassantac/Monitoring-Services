using Meetings.Repositories.Interface.Unit;
using Meetings.Services.Implementation.GetServices;
using Meetings.Services.Interface;
using Meetings.Services.Interface.GetServices;
using Meetings.Services.Interface.Unit;

namespace Meetings.Services.Implementation.Unit
{
    internal class ServiceUnit : IServiceUnit
    {
        #region Private Fields
        private readonly IRepositoryUnit _repo;
        private IUserService _user;
        private IAllService _all;
        private IByIdService _byId;
        private IOperatorService _operator;
        private ISchoolService _school;
        private IClassOfSchoolService _classOfSchool;
        private IGradeService _grade;
        private ISchoolGradeService _schoolGrade;
        private ISubjectService _subject;
        private ISubjectClassService _subjectClass;
        private IUserEventService _userEvent;
        private ICalenderEventService _calenderEvent;
        #endregion

        #region Private Methods

        #endregion

        #region Constructor
        public ServiceUnit(IRepositoryUnit repo)
        {
            _repo = repo;
        }
        #endregion

        #region Properties

        #endregion

        #region Fields
        public IUserService User =>
            _user ??= new UserService(_repo);

        public IAllService All =>
            _all ??= new AllService(_repo);

        public IByIdService ById =>
            _byId ??= new ByIdService(_repo);

        public IOperatorService Operator =>
            _operator ??= new OperatorService(_repo);

        public ISchoolService School =>
             _school ??= new SchoolService(_repo);

        public IClassOfSchoolService ClassOfSchool =>
             _classOfSchool ??= new ClassOfSchoolService(_repo);

        public IGradeService Grade =>
             _grade ??= new GradeService(_repo);

        public ISchoolGradeService SchoolGrade =>
             _schoolGrade ??= new SchoolGradeService(_repo);

        public ISubjectService Subject =>
             _subject ??= new SubjectService(_repo);

        public ISubjectClassService SubjectClass =>
             _subjectClass ??= new SubjectClassService(_repo);

        public IUserEventService UserEvent =>
            _userEvent ??= new UserEventService(_repo);

        public ICalenderEventService Event =>
            _calenderEvent ??= new CalenderEventService(_repo);
        #endregion

        #region Methods
        public void BeginTransaction()
        {
            _repo.BeginTransaction();
        }

        public void CommitTransaction()
        {
            _repo.CommitTransaction();
        }

        public void RollBackTransaction()
        {
            _repo.RollBackTransaction();
        }
        #endregion

    }
}
