namespace Meetings.API.ObjectConverters.Interface.Unit
{
    public interface IConverterUnit
    {
        IUserConverter User { get; }
        IEventConverter Event { get; }
    }
}