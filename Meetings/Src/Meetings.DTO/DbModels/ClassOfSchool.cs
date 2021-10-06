using Meetings.DTO.Common;
using System.Collections.Generic;

namespace Meetings.DTO.DbModels
{
    public class ClassOfSchool : CommonDbProp
    {
        public ClassOfSchool()
        {
            SubjectClasses = new HashSet<SubjectClass>();
        }
        public string ClassName { get; set; }
        public string ShortName { get; set; }
        public string SecondaryName { get; set; }
        public string MailNickName { get; set; }
        public string TeamsObjectId { get; set; }
        public long SchoolGrade_Id { get; set; }


        public virtual SchoolGrade SchoolGrade { get; set; }
        public virtual ICollection<SubjectClass> SubjectClasses { get; set; }
    }
}
