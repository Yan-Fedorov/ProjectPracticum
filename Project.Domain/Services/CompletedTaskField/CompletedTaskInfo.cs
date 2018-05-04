using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Domain.Services.CompletedTaskField
{
    public class CompletedTaskInfo
    {
        public Task Task { get; set; }
        public double ReceivedPoints { get; set; }
        public string Solution { get; set; }
    }
}
