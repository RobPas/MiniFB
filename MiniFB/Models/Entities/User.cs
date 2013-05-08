using System;
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
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }

        public string Salt { get; set; }
        public string PasswordHash { get; set; }
        

        [DisplayName("Kön")]
        public string Sex { get; set; }

        public virtual List<NewsFeedItem> NewsFeedItems { get; set; }

        public int Age {
            get {
                int _age = DateTime.Now.Year - BirthDate.Year;
                return _age; 
            }
            
        }
    }
    
}
