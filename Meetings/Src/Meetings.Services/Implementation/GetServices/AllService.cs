using Meetings.DTO.DbModels;
using Meetings.Repositories.Interface.Unit;
using Meetings.Services.Interface.GetServices;
using System.Linq;

namespace Meetings.Services.Implementation.GetServices
{
    internal class AllService : IAllService
    {
        #region Private Fields
        private readonly IRepositoryUnit _repo;
        #endregion

        #region Private Methods

        #endregion

        #region Constructor
        public AllService(IRepositoryUnit repo)
        {
            _repo = repo;
        }
        #endregion

        #region Properties

        #endregion

        #region Fields

        #endregion

        #region Methods
        public IQueryable<User> GetUsers()
        {
            return _repo.User.FindByCondition(f => !f.IsDeleted);
        }
        public IQueryable<ClassOfSchool> GetClassesOfSchool()
        {
            return _repo.ClassOfSchool.FindByCondition(f => !f.IsDeleted);
        }

        public IQueryable<Grade> GetGrades()
        {
            return _repo.Grade.FindByCondition(f => !f.IsDeleted);
        }

        public IQueryable<Operator> GetOperators()
        {
            return _repo.Operator.FindByCondition(f => !f.IsDeleted);
        }

        public IQueryable<SchoolGrade> GetSchoolGrades()
        {
            return _repo.SchoolGrade.FindAll();
        }

        public IQueryable<School> GetSchools()
        {
            return _repo.School.FindByCondition(f => !f.IsDeleted);
        }

        public IQueryable<SubjectClass> GetSubjectClasses()
        {
            return _repo.SubjectClass.FindAll();
        }

        public IQueryable<Subject> GetSubjects()
        {
            return _repo.Subject.FindByCondition(f => !f.IsDeleted);
        }
        public IQueryable<UserEvent> GetUserEvents()
        {
            return _repo.UserEvent.FindAll();
        }

        public IQueryable<CalenderEvent> GetEvents()
        {
            return _repo.CalenderEvent.FindAll();
        }
        #endregion
    }
}
