using RPiWebsiteNET5.Data;
using RPiWebsiteNET5.Models;
using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;

namespace RPiWebsiteNET5.Data
{
    public static class DbInitializer
    {
        public static void Initialize(RPiWebsiteContext context)
        {
            context.Database.EnsureCreated();

            // Look for any users.
            if (context.Users.Any())
            {
                return;   // DB has been seeded
            }

            PasswordHasher<User> passHasher = new PasswordHasher<User>();

            User adminUser = new User
            {
                FirstName="Admin",
                LastName="User",
                Username="admin",
                IsAdmin=true
            };

            adminUser.PasswordHash = passHasher.HashPassword(adminUser, "admin");

            context.Users.Add(adminUser);

            User dwoodUser = new User
            {
                FirstName="Donald",
                MiddleName="James",
                LastName="Wood",
                Username="dwood",
                Email="donwood@gmail.com",
                IsAdmin=true
            };

            dwoodUser.PasswordHash = passHasher.HashPassword(dwoodUser, "FooBar");

            context.Users.Add(dwoodUser);

            context.SaveChanges();
        }
    }
}