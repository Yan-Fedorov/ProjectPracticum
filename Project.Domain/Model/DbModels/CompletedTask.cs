using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Domain
{
    public class CompletedTask:DtoBase
    {
        public Task Task { get; set; }
        public double ReceivedPoints { get; set; }
        public string Solution { get; set; }

    }
}
