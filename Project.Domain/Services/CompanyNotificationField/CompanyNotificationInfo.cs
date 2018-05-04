using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Domain.Services.CompanyNotificationField
{
    public class CompanyNotificationInfo
    {
        public virtual ICollection<Company_Notification> Companies { get; set; }
        public DateTime DateTime { get; set; }
        public string Info { get; set; }
    }
}
