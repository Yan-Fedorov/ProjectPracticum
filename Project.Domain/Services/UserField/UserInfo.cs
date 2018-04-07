using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Domain.Services.UserField
{
    public class UserInfo
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string UserEmail { get; set; }
    }
}
