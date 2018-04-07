using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Domain.Model
{
    public class UsersTasks
    {
        public User user { get; set; }
        public ICollection<Task> tasks { get; set; }
    }
}
