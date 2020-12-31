using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RPiWebsiteNET5.Models
{
    public class User 
    {
        public int ID {get; set;}
        [Display(Name = "First Name")]
        public string FirstName {get; set;}
        [Display(Name = "Middle Name")]
        public string MiddleName {get; set;}
        [Display(Name = "Last Name")]
        [Required]
        [StringLength(100, MinimumLength=2)]
        public string LastName {get; set;}
        [Display(Name = "Email")]
        public string Email {get; set;}
        [Display(Name = "Username")]
        [Required]
        [StringLength(100, MinimumLength=2)]
        public string Username {get; set;}
        [Display(Name = "Password Hash")]
        [Required]
        public string PasswordHash {get; set;}
        [Display(Name = "Is Admin")]
        public bool IsAdmin {get; set;}

    }
}