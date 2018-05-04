using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Domain
{
    public class CompanyNotification: DtoBase
    {
        //public CompanyNotification()
        //{
        //    this.Companies = new HashSet<Company>();
        //}
        public virtual ICollection<Company_Notification> Companies { get; set; }
        public DateTime DateTime { get; set; }
        public string Info { get; set; }
    }
}
