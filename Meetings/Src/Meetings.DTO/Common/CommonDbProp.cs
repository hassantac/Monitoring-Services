using System;

namespace Meetings.DTO.Common
{
    public class CommonDbProp
    {
        public long Id { get; set; }
        public bool IsDeleted { get; set; } = false;
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeleteAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
    }
}
