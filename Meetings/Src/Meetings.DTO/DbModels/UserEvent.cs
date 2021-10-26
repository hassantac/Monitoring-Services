namespace Meetings.DTO.DbModels
{
    public class UserEvent
    {
        public long Id { get; set; }
        public long User_Id { get; set; }
        public long Event_Id { get; set; }
        public virtual CalenderEvent CalenderEvent { get; set; }
        public virtual User User { get; set; }
    }
}