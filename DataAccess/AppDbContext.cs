using Microsoft.EntityFrameworkCore;
using Models;

namespace DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }


        public DbSet<User> Users { get; set; } 
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<UserWallet> UserWallets { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    FirstName = "Levon",
                    LastName = "Mardanyan"
                },
                new User
                {
                    Id = 2,
                    FirstName = "admin",
                    LastName = "admin"
                });


            modelBuilder.Entity<Wallet>().HasData(
            new Wallet
            {
                Id = 1,
                CurrencyCode = "EUR",
                CurrencyName = "Euro",
                Description = "European Euro"

            },
            new Wallet
            {
                Id = 2,
                CurrencyCode = "USD",
                CurrencyName = "Dollar",
                Description = "US Dollar"
            },
            new Wallet
            {
                Id = 3,
                CurrencyCode = "RUB",
                CurrencyName = "Ruble",
                Description = "Russian Ruble"
            });


            modelBuilder.Entity<UserWallet>().HasData(
                new UserWallet
                {
                    Id = 1,
                    Balance = 0,
                    UserId = 1,
                    WalletId = 1
                },
                new UserWallet
                {
                    Id = 2,
                    Balance = 0,
                    UserId = 1,
                    WalletId = 2
                },
                new UserWallet
                {
                    Id = 3,
                    Balance = 0,
                    UserId = 2,
                    WalletId = 1
                },
                new UserWallet
                {
                    Id = 4,
                    Balance = 0,
                    UserId = 2,
                    WalletId = 2
                },
                new UserWallet
                {
                    Id = 5,
                    Balance = 0,
                    UserId = 2,
                    WalletId = 3
                }
            );
           base.OnModelCreating(modelBuilder);
        }

    }
}
