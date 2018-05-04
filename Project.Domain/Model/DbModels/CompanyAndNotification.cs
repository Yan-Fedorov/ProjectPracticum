using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Domain
{
    public class Company_Notification:DtoBase
    {
        public Company Company { get; set; }
        public CompanyNotification CompanyNotification { get; set; }
    }
}
