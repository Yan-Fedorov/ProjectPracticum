using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Domain
{
    public class Task : DtoBase
    {
        public string Info { get; set; }
        public int Points { get; set; }
        public string answers { get; set; }
    }
}
