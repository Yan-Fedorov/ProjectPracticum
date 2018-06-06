using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Domain.Services.TaskField
{
    public class TaskInfo
    {
        public Guid Id { get; set; }
        public string Info { get; set; }
        public int Points { get; set; }
        public string Answers { get; set; }
        public string Name { get; set; }
    }
}
