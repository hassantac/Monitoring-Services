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
        private IUserEventRepository _userEvent;
        private ICalenderEventRepository _calenderEvent;

        #endregion Private Fields



        #region Constructor

        public RepositoryUnit(MeetingsContext db)
        {
            _db = db;
        }

        #endregion Constructor



        #region Fields

        public IUserRepository User =>
            _user ??= new UserRepository(_db);

        public ICalenderEventRepository CalenderEvent =>
            _calenderEvent ??= new CalenderEventRepository(_db);

        public IUserEventRepository UserEvent =>
            _userEvent ??= new UserEventRepository(_db);

        #endregion Fields

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

        #endregion Methods
    }
}