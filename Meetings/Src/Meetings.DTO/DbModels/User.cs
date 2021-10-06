using Meetings.Common.Enums;
using Meetings.DTO.Common;
using System.Collections.Generic;

namespace Meetings.DTO.DbModels
{
    public class User : CommonDbProp
    {
        public User()
        {
            UserEvents = new HashSet<UserEvent>();
        }
        public string Username { get; set; }
        public string User_Id { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public AccountType AccountType { get; set; }
        public virtual ICollection<UserEvent> UserEvents { get; set; }

    }


}
