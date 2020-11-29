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
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<WalletCurrency> WalletCurrencies { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<User>()
            //    .HasOne(u => u.Wallet) // Mark Address property optional in Student entity
            //    .WithOne(w => w.User)
            //    .IsRequired();

            modelBuilder.Entity<Currency>().HasData(
                new Currency
                {
                    Id = 1,
                    CurrencyCode = "EUR",
                    Name = "Euro"
                },
                new Currency
                {
                    Id = 2,
                    CurrencyCode = "USD",
                    Name = "US Dollar"
                },
                new Currency
                {
                    Id = 3,
                    CurrencyCode = "RUB",
                    Name = "Ruble"
                });

            //modelBuilder.Entity<Wallet>().HasData(
            //new Wallet
            //{
            //    Id = 1,
            //    UserId = 1
            //},
            //new Wallet
            //{
            //    Id = 2,
            //    UserId = 2
            //});

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    FirstName = "Levon",
                    LastName = "Mardanyan",
                    Wallet = new Wallet{Id = 1}
                },
                new User
                {
                    Id = 2,
                    FirstName = "admin",
                    LastName = "admin",
                    Wallet = new Wallet { Id = 1 }
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}
