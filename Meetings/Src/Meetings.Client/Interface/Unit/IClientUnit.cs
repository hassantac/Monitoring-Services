namespace Meetings.Client.Interface.Unit
{
    public interface IClientUnit
    {
        IGraphClient Graph { get; }
        IAdminClient Admin { get; }
    }
}