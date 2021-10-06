namespace Meetings.API.ObjectConverters.Interface.Unit
{
    public interface IConverterUnit
    {
        IUserConverter User { get; }
        IClassOfSchoolConverter ClassOfSchool { get; }
        ISchoolConverter School { get; }
        IEventConverter Event { get; }
    }
}
