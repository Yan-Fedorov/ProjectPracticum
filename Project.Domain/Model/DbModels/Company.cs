using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Domain
{
    public class Company:DtoBase
    {
        public string Name { get; set; }
        public string Contacts { get; set; }
        public string Info { get; set; }
        public ICollection<Course> Courses { get; set; }

        public string SomeProp { get; set; }

    }
}
