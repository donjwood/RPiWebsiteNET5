using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

using RPiWebsiteNET5.Models;

namespace RPiWebsiteNET5.ViewModels
{
    public class UserVM
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
        //[Remote(action: "isUsernameAvailable",controller:"Validation", HttpMethod = "POST",  AdditionalFields = "ID", ErrorMessage="This username has already been taken.")]
        public string Username {get; set;}
        [Display(Name = "Is Admin")]
        public bool IsAdmin {get; set;}
        
        
        public UserVM() {}

        public UserVM(User aUser)
        {
            LoadFrom(aUser);
        }

        public void LoadFrom(User aUser)
        {
            ID = aUser.ID;
            FirstName = aUser.FirstName;
            MiddleName = aUser.MiddleName;
            LastName = aUser.LastName;
            Email = aUser.Email;
            Username = aUser.Username;
            IsAdmin = aUser.IsAdmin;
        }

    }
}