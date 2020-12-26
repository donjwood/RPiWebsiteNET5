using System;
using System.Collections.Generic;

namespace RPiWebsiteNET5.Models
{
    public class User 
    {
        public int ID {get; set;}
        public string FirstName {get; set;}
        public string MiddleName {get; set;}
        public string LastName {get; set;}
        public string Email {get; set;}
        public string UserName {get; set;}
        public string PasswordHash {get; set;}
        public bool IsAdmin {get; set;}

    }
}