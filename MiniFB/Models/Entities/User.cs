using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MiniFB.Entities.Abstract;

namespace MiniFB.Models.Entities
{
    public class User : IEntity
    {
        public Guid ID { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string Sex { get; set; }
        public string Password { get; set; }
        public Guid NewsFeedID { get; set; }
    }
}