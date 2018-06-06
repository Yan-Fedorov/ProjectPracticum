using System;
using System.Collections.Generic;
using System.Text;

namespace Project.Domain
{
    public class Task : DtoBase
    {
        public string Info { get; set; }
        public int Points { get; set; }
        public string Answers { get; set; }
        public Course Course { get; set; }
        public string Name { get; set; }

    }
}
