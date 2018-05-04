using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Domain.Services.CompanyField
{
    public class CompanyInfo
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Contacts { get; set; }
        public string Info { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<Company_Notification> Notifications { get; set; }

    }
}
