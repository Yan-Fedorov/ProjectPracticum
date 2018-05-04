using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Domain.Services.UserNotificationField
{
    public class UserNotificationInfo
    {
        public virtual ICollection<UserAndNotification> Users { get; set; }
        public DateTime DateTime { get; set; }
        public string Info { get; set; }
    }
}
