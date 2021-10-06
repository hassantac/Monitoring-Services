using Meetings.EF;
using Meetings.Repositories.Interface;
using Meetings.Repositories.Interface.Unit;
using Microsoft.EntityFrameworkCore;

namespace Meetings.Repositories.Implementation.Unit
{
    internal class RepositoryUnit : IRepositoryUnit
    {

        #region Private Fields
        private readonly MeetingsContext _db;
        private IUserRepository _user;
        private IOperatorRepository _operator;
        private ISchoolRepository _school;
        private IClassOfSchoolRepository _classOfSchool;
        private IGradeRepository _grade;
        private ISchoolGradeRepository _schoolGrade;
        private ISubjectRepository _subject;
        private ISubjectClassRepository _subjectClass;
        private IUserEventRepository _userEvent;
        private ICalenderEventRepository _calenderEvent;
        #endregion

        #region Private Methods

        #endregion

        #region Constructor
        public RepositoryUnit(MeetingsContext db)
        {
            _db = db;
        }
        #endregion

        #region Properties

        #endregion

        #region Fields
        public IUserRepository User =>
            _user ??= new UserRepository(_db);

        public IOperatorRepository Operator =>
            _operator ??= new OperatorRepository(_db);

        public ISchoolRepository School =>
             _school ??= new SchoolRepository(_db);

        public IClassOfSchoolRepository ClassOfSchool =>
             _classOfSchool ??= new ClassOfSchoolRepository(_db);

        public IGradeRepository Grade =>
             _grade ??= new GradeRepository(_db);

        public ISchoolGradeRepository SchoolGrade =>
             _schoolGrade ??= new SchoolGradeRepository(_db);

        public ISubjectRepository Subject =>
             _subject ??= new SubjectRepository(_db);

        public ISubjectClassRepository SubjectClass =>
             _subjectClass ??= new SubjectClassRepository(_db);

        public ICalenderEventRepository CalenderEvent =>
            _calenderEvent ??= new CalenderEventRepository(_db);

        public IUserEventRepository UserEvent =>
            _userEvent ??= new UserEventRepository(_db);
        #endregion

        #region Methods
        public void Save()
        {
            _db.SaveChanges();
        }

        public void Save<TEntity>(TEntity entity)
        {
            _db.SaveChanges();

            _db.Entry(entity).State = EntityState.Detached;
        }

        public void BeginTransaction()
        {
            _db.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            _db.Database.CommitTransaction();
        }

        public void RollBackTransaction()
        {
            _db.Database.RollbackTransaction();
        }
        #endregion

    }
}
