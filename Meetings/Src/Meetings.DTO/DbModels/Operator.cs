using Meetings.DTO.Common;
using System.Collections.Generic;

namespace Meetings.DTO.DbModels
{
    public class Operator : CommonDbProp
    {
        public Operator()
        {
            Schools = new HashSet<School>();
        }
        public long Operator_Id { get; set; }
        public string OperatorName { get; set; }

        public virtual ICollection<School> Schools { get; set; }
    }
}
