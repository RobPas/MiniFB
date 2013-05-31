using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MiniFB.Entities.Abstract;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Security;

namespace MiniFB.Models.Entities
{
    public class User : IEntity
    {

        [Key]
        public Guid ID { get; set; }
        
        public string Password { get; set; }
        public string Salt { get; set; }

        public string ConfirmationToken { get; set; }
        
        public bool IsAdmin { get; set; } 

        public bool IsConfirmed { get; set; }


        public string UserSecretQuestion { get; set; }
        public string UserSecretAnswer { get; set; }

		[DisplayName("Användarnamn")]
        public string UserName { get; set; }

        [DisplayName("Förnamn")]
        public string FirstName { get; set; }

        [DisplayName("Efternamn")]
        public string LastName { get; set; }

        [DisplayName("Epost")]
        public string Email { get; set; }

        public bool IsUsingGravatar { get; set; }

        public string ProfileImageUrl
        {
            get
            {
                if (this.IsUsingGravatar)
                {
                    string md5hash = Encryptor.MD5Hash(this.Email.Trim().ToLower());

                    return String.Format("http://gravatar.com/avatar/{0}?s=300", md5hash);
                }

                return "http://placehold.it/300";
            }
        }

        [DisplayName("Födelsedatum")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }

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

    public class UserProfileSettings 
    { 
        public Guid UserID { get; set; }

        [DisplayName("Förnamn")]
        public string FirstName { get; set; }

        [DisplayName("Efternamn")]
        public string LastName { get; set; }

        [DisplayName("Epost")]
        public string Email { get; set; }

        public bool IsUsingGravatar { get; set; }
        
        [DisplayName("Födelsedatum")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }
               
        [DisplayName("Kön")]
        public string Sex { get; set; }

    }



    public class ChangePasswordByEmailModel
    {
        public string Email { get; set; }
    }

    public class ForgotPasswordModel
    {
        public Guid UserID { get; set; }
        public string UserSecretQuestion { get; set; }
        public string UserSecretAnswer { get; set; }

        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }
    
}
