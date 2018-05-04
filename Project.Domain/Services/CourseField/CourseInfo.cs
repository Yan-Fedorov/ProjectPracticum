using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Domain.Services.CourseField
{
    public class CourseInfo
    {
        public string Name { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Vacancy { get; set; }
        public int PeopleLimit { get; set; }
        public ICollection<Task> Tasks { get; set; }
    }
}
