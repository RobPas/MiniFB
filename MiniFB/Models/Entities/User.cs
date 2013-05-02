﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MiniFB.Entities.Abstract;
using System.ComponentModel;

namespace MiniFB.Models.Entities
{
    public class User : IEntity
    {
        public Guid ID { get; set; }

        [DisplayName("Användarnamn")]
        public string UserName { get; set; }

        [DisplayName("Förnamn")]
        public string FirstName { get; set; }

        [DisplayName("Efternamn")]
        public string LastName { get; set; }

        [DisplayName("Epost")]
        public string Email { get; set; }

        [DisplayName("Födelsedatum")]
        public DateTime BirthDate { get; set; }

        [DisplayName("Kön")]
        public string Sex { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = " {0} måste vara minst {2} tecken lång.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Lösenord")]
        public string Password { get; set; }

        public Guid NewsFeedID { get; set; }

        public virtual List<NewsFeedItem> NewsFeedItems { get; set; }

        public int Age {
            get {
                int _age = DateTime.Now.Year - BirthDate.Year;
                return _age; 
            }
            
        }
    }
    
}
