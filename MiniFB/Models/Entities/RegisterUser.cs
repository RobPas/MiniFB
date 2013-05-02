using MiniFB.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MiniFB.Models.Entities
{
    public class RegisterUser :IEntity
    {
        
            public Guid ID { get; set; }

            [DisplayName("Användarnamn")]
            public string UserName { get; set; }

            [DisplayName("Epost")]
            public string Email { get; set; }


            [DisplayName("Kön")]
            public bool Sex { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = " {0} måste vara minst {2} tecken lång.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Lösenord")]
            public string Password { get; set; }


            [DataType(DataType.Password)]
            [Display(Name = "Bekräfta Lösenord")]
            [Compare("Password", ErrorMessage = "Fel lösenord.")]
            public string ConfirmPassword { get; set; }

        
    }
}