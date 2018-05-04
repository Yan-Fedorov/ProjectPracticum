using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Domain.Services.UserField
{
    public class UserInfo
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Info { get; set; }
        public ICollection<CompletedTask> CompletedTasks { get; set; }
        public virtual ICollection<UserAndNotification> Notifications { get; set; }
    }
}
