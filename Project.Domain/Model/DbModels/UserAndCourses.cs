using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Domain
{
    public class UserAndCourses : DtoBase
    {
        public User User { get; set; }
        public Course Course { get; set; }
    }
}
