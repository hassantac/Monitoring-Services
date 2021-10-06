using System.Collections.Generic;

namespace Meetings.DTO.DbModels
{
    public class SchoolGrade
    {
        public long Id { get; set; }
        public long School_Id { get; set; }
        public long Grade_Id { get; set; }

        public virtual School School { get; set; }
        public virtual Grade Grade { get; set; }
        public virtual ICollection<ClassOfSchool> ClassesOfSchool { get; set; }
    }
}
