using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RPiWebsiteNET5.Models;

namespace RPiWebsiteNET5.Data
{
    public class RPiWebsiteContext : DbContext
    {
        public RPiWebsiteContext (DbContextOptions<RPiWebsiteContext> options)
            : base(options)
        {
        }

        public DbSet<RPiWebsiteNET5.Models.User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
        }
    }
}
