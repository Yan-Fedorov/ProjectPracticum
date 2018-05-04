using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Domain
{
    public class UserNotification: DtoBase
    {
        //public UserNotification()
        //{
        //    this.Users = new HashSet<User>();
        //}
        public virtual ICollection<UserAndNotification> Users { get; set; }
        public DateTime DateTime { get; set; }
        public string Info { get; set; }
    }
}
