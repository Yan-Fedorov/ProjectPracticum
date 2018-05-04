using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Domain
{
    public class UserAndNotification:DtoBase
    {
        public User User { get; set; }
        public UserNotification UserNotification { get; set; }
    }
}
