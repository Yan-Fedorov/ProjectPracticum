using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Domain.Services.CompanyField
{
    public class CompanyInfo
    {
        public string CompanyName { get; set; }
        public string CompanyContacts { get; set; }
        public string ComInfo { get; set; }
        public ICollection<Course> CompanyCourses { get; set; }

    }
}
