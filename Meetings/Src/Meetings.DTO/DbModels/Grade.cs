using Meetings.DTO.Common;
using System.Collections.Generic;

namespace Meetings.DTO.DbModels
{
    public class Grade : CommonDbProp
    {
        public Grade()
        {
            SchoolGrades = new HashSet<SchoolGrade>();
        }
        public long Grade_Id { get; set; }
        public string GradeName { get; set; }

        public virtual ICollection<SchoolGrade> SchoolGrades { get; set; }
    }
}
