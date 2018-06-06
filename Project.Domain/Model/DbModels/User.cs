using System;
using System.Collections.Generic;

namespace Project.Domain
{
    public class User : DtoBase
    {
        //public User()
        //{
        //    this.UserNotifications = new HashSet<UserNotification>();
        //}
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Info { get; set; }
        public ICollection<CompletedTask> CompletedTasks { get; set; }
        public virtual ICollection<UserAndNotification> Notifications { get; set; }
        public virtual ICollection<UserAndCourses> Courses { get; set; }

    }
}
