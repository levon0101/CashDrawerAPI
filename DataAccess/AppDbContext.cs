using Microsoft.EntityFrameworkCore;
using System;
using Models;

namespace DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }


        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    FirstName = "Levon",
                    LastName = "Mardanyan",
                },
                new User
                {
                    Id = 2,
                    FirstName = "admin",
                    LastName = "admin",
                }
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}
