using System;

namespace Project.Domain
{
    public class User : DtoBase
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
