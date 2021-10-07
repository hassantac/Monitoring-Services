namespace Meetings.Repositories.Interface.Unit
{
    public interface IRepositoryUnit
    {
        IUserRepository User { get; }
        ICalenderEventRepository CalenderEvent { get; }
        IUserEventRepository UserEvent { get; }

        void Save();
        void Save<TEntity>(TEntity entity);
        void BeginTransaction();
        void CommitTransaction();
        void RollBackTransaction();
    }
}
