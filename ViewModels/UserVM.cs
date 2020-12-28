using System;
using System.Collections.Generic;

using RPiWebsiteNET5.Models;

namespace RPiWebsiteNET5.ViewModels
{
    public class UserVM
    {
        public int ID {get; set;}
        public string FirstName {get; set;}
        public string MiddleName {get; set;}
        public string LastName {get; set;}
        public string Email {get; set;}
        public string UserName {get; set;}
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
            UserName = aUser.UserName;
            IsAdmin = aUser.IsAdmin;
        }

        public void SaveTo(User aUser)
        {
            aUser.ID = ID;
            aUser.FirstName = FirstName;
            aUser.MiddleName = MiddleName;
            aUser.LastName = LastName;
            aUser.Email = Email;
            aUser.UserName = UserName;
            aUser.IsAdmin = IsAdmin;
        }

    }
}