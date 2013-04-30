using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MiniFB.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Sex { get; set; }
        public string Password { get; set; }
    }
}