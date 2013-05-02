﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MiniFB.Entities.Abstract;

namespace MiniFB.Models.Entities
{
    public class User : IEntity
    {
        public Guid ID { get; set; }
        public string UserName { get; set; }

        [Display(Name = "Namn")]
        public string FirstName { get; set; }

        [Display(Name = "Efternamn")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Display(Name = "Födelse datum")]
        public DateTime BirthDate { get; set; }

        [Required]
        [Display(Name = "Jag är en:")]
        public bool Sex { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = " {0} måste vara minst {2} tecken lång.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Lösenord")]
        public string Password { get; set; }
        public Guid NewsFeedID { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Bekräfta Lösenord")]
        [Compare("Password", ErrorMessage = "Fel lösenord.")]
        public string ConfirmPassword { get; set; }

    }
}