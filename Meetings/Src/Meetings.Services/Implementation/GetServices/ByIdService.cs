using Meetings.DTO.DbModels;
using Meetings.Repositories.Interface.Unit;
using Meetings.Services.Interface.GetServices;
using System.Linq;

namespace Meetings.Services.Implementation.GetServices
{
    internal class ByIdService : IByIdService
    {
        #region Private Fields
        private readonly IRepositoryUnit _repo;
        private readonly IAllService _all;
        #endregion

        #region Private Methods

        #endregion

        #region Constructor
        public ByIdService(IRepositoryUnit repo)
        {
            _repo = repo;
            _all = new AllService(_repo);
        }


        #endregion

        #region Properties

        #endregion

        #region Fields

        #endregion

        #region Methods
        public bool AnyUser(long id)
        {
            return _all.GetUsers().Any(a => a.Id == id);
        }

        public bool AnyClassOfSchool(long id)
        {
            return _all.GetClassesOfSchool().Any(a => a.Id == id);
        }

        public bool AnyGrade(long id)
        {
            return _all.GetGrades().Any(a => a.Id == id);
        }

        public bool AnyOperator(long id)
        {
            return _all.GetOperators().Any(a => a.Id == id);
        }

        public bool AnySchool(long id)
        {
            return _all.GetSchools().Any(a => a.Id == id);
        }

        public bool AnySchoolGrade(long id)
        {
            return _all.GetSchoolGrades().Any(a => a.Id == id);
        }

        public bool AnySubject(long id)
        {
            return _all.GetSubjects().Any(a => a.Id == id);
        }

        public bool AnySubjectClass(long id)
        {
            return _all.GetSubjectClasses().Any(a => a.Id == id);
        }

        public bool AnyEvent(long id)
        {
            return _all.GetEvents().Any(a => a.Id == id);
        }

        public CalenderEvent GetEvent(long id)
        {
            return _all.GetEvents().FirstOrDefault(a => a.Id == id);
        }

        public UserEvent GetUserEvent(long id)
        {
            return _all.GetUserEvents().FirstOrDefault(a => a.Id == id);
        }

        public ClassOfSchool GetClassOfSchool(long id)
        {
            return _all.GetClassesOfSchool().FirstOrDefault(a => a.Id == id);
        }

        public Grade GetGrade(long id)
        {
            return _all.GetGrades().FirstOrDefault(a => a.Id == id);
        }

        public Operator GetOperator(long id)
        {
            return _all.GetOperators().FirstOrDefault(a => a.Id == id);
        }

        public School GetSchool(long id)
        {
            return _all.GetSchools().FirstOrDefault(a => a.Id == id);
        }

        public SchoolGrade GetSchoolGrade(long id)
        {
            return _all.GetSchoolGrades().FirstOrDefault(a => a.Id == id);
        }

        public Subject GetSubject(long id)
        {
            return _all.GetSubjects().FirstOrDefault(a => a.Id == id);
        }

        public SubjectClass GetSubjectClass(long id)
        {
            return _all.GetSubjectClasses().FirstOrDefault(a => a.Id == id);
        }

        public User GetUser(long id)
        {
            return _all.GetUsers().FirstOrDefault(a => a.Id == id);
        }
        #endregion
    }
}
