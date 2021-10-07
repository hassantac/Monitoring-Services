using Meetings.Services.Interface.GetServices;

namespace Meetings.Services.Interface.Unit
{
    public interface IServiceUnit
    {
        IUserService User { get; }
        IAllService All { get; }
        IByIdService ById { get; }

        IUserEventService UserEvent { get; }
        ICalenderEventService Event { get; }

        void BeginTransaction();
        void CommitTransaction();
        void RollBackTransaction();
    }
}
