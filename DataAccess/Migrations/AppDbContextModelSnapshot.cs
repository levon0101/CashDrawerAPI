﻿// <auto-generated />
using DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccess.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            FirstName = "Levon",
                            LastName = "Mardanyan"
                        },
                        new
                        {
                            Id = 2L,
                            FirstName = "admin",
                            LastName = "admin"
                        });
                });

            modelBuilder.Entity("Models.UserWallet", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<double>("Balance")
                        .HasColumnType("float");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<long>("WalletId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("WalletId");

                    b.ToTable("UserWallets");
                });

            modelBuilder.Entity("Models.Wallet", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<string>("CurrencyCode")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<string>("CurrencyName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Description")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Wallets");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CurrencyCode = "EUR",
                            CurrencyName = "Euro",
                            Description = "European Euro"
                        },
                        new
                        {
                            Id = 2L,
                            CurrencyCode = "USD",
                            CurrencyName = "Dollar",
                            Description = "US Dollar"
                        },
                        new
                        {
                            Id = 3L,
                            CurrencyCode = "RUB",
                            CurrencyName = "Ruble",
                            Description = "Russian Ruble"
                        });
                });

            modelBuilder.Entity("Models.UserWallet", b =>
                {
                    b.HasOne("Models.User", "User")
                        .WithMany("UserWallets")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Wallet", "Wallet")
                        .WithMany("UserWallets")
                        .HasForeignKey("WalletId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");

                    b.Navigation("Wallet");
                });

            modelBuilder.Entity("Models.User", b =>
                {
                    b.Navigation("UserWallets");
                });

            modelBuilder.Entity("Models.Wallet", b =>
                {
                    b.Navigation("UserWallets");
                });
#pragma warning restore 612, 618
        }
    }
}
