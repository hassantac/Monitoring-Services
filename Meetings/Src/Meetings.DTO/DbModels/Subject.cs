using Meetings.DTO.Common;
using System.Collections.Generic;

namespace Meetings.DTO.DbModels
{
    public class Subject : CommonDbProp
    {
        public Subject()
        {
            SubjectClasses = new HashSet<SubjectClass>();
        }
        public string SubjectName { get; set; }
        public long Subject_Id { get; set; }

        public virtual ICollection<SubjectClass> SubjectClasses { get; set; }
    }
}
