namespace Meetings.DTO.DbModels
{
    public class SubjectClass
    {
        public long Id { get; set; }
        public long Subject_Id { get; set; }
        public long Class_Id { get; set; }

        public virtual Subject Subject { get; set; }
        public virtual ClassOfSchool ClassOfSchool { get; set; }
    }
}
