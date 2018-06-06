using Project.Domain.Services.TaskField;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Domain.Services.UserAndCoursesField
{
    public class UserAndCoursesInfo
    {
        public Guid? CoursId { get; set; }
        public string Name { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public ICollection<TaskInfo> Tasks { get; set; }
    }
}
