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


        public DbSet<Wallet> Wallets { get; set; }

    }
}
