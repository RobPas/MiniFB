using MiniFB.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MiniFB.Models.Entities
{
    public class ChangePasswordModel
    {


        public Guid UserID { get; set; }

        [Required(ErrorMessage = "Detta fält är obligatoriskt.")]
        [DataType(DataType.Password)]
        [Display(Name = "Gammalt lösenord")]
        public string OldPassword { get; set; }


        [Required]
        [StringLength(100, ErrorMessage = " {0} måste vara minst {2} tecken lång.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Nytt lösenord")]
        public string NewPassword { get; set; }


        [DataType(DataType.Password)]
        [Display(Name = "Upprepa nytt lösenord")]
        [Compare("NewPassword", ErrorMessage = "Lösenorden stämmer inte överens.")]
        public string ConfirmPassword { get; set; }



    }
}