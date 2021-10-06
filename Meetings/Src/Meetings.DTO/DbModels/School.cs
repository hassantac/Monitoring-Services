using Meetings.Common.Enums;
using Meetings.DTO.Common;
using System.Collections.Generic;

namespace Meetings.DTO.DbModels
{
    public class School : CommonDbProp
    {
        public School()
        {
            SchoolGrades = new HashSet<SchoolGrade>();
        }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Address { get; set; }
        public string ContactUs { get; set; }
        public string PrincipalName { get; set; }
        public SchoolType SchoolType { get; set; }
        public string ContactNumber { get; set; }
        public string Principal { get; set; }
        public string Emirate { get; set; }
        public string Abbreviaton { get; set; }
        public long Operator_Id { get; set; }


        public virtual Operator Operator { get; set; }


        public virtual ICollection<SchoolGrade> SchoolGrades { get; set; }
    }
}
