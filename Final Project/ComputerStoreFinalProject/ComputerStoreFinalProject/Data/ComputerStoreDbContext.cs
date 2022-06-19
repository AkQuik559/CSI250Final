using ComputerStoreFinalProject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace ComputerStoreFinalProject.Data
{
    public class ComputerStoreDbContext : IdentityDbContext
    {
        //Constructor that takes in options
        //We will hit this in the Startup.cs
        public ComputerStoreDbContext(DbContextOptions<ComputerStoreDbContext> options) : base(options)
        {

        }

        //collections - DbSet - Each table in the database will need this
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Computer> Computers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ComputerOrder> ComputerOrders { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Computer>().HasData(
                new Computer() { ID = 1, CompanyName = "Hp", ComputerModel = "notebook 360", Year = 2019, Price = 899.99m },
                new Computer() { ID = 2, CompanyName = "Dell", ComputerModel = "Latitude 7420", Year = 2022, Price = 2029.00m },
                new Computer() { ID = 3, CompanyName = "Apple", ComputerModel = "MacBook Pro", Year = 2021, Price = 3499.00m },
                new Computer() { ID = 4, CompanyName = "Asus", ComputerModel = "Zenbook Duo", Year = 2022, Price = 2299.00m },
                new Computer() { ID = 5, CompanyName = " Asus", ComputerModel = "VivoBook Flip", Year = 2022, Price = 269.00m },
                new Computer() { ID = 6, CompanyName = "Dell", ComputerModel = "Vostro 3510", Year = 2022, Price = 629.00m },
                new Computer() { ID = 7, CompanyName = "Hp", ComputerModel = "Omen", Year = 2021, Price = 2349.99m },
                new Computer() { ID = 8, CompanyName = "Apple", ComputerModel = "MacBook Air", Year = 2022, Price = 1199.00m }
                );

            modelBuilder.Entity<Customer>().HasData(
                new Customer() { ID = 1, FirstName = "Brynne", LastName = "Mayhou", Phone = "966-926-0620", Email = "bmayhou0@imageshack.us", Mobile = "758-562-6470" },
                new Customer() { ID = 2, FirstName = "Margaretha", LastName = "Vela", Phone = "217-861-7584", Email = "mvela1@flickr.com", Mobile = "684-651-3264" },
                new Customer() { ID = 3, FirstName = "Amalia", LastName = "Mapother", Phone = "595-428-3323", Email = "amapother2@is.gd", Mobile = "673-740-4441" },
                new Customer() { ID = 4, FirstName = "Padden", LastName = "Quill", Phone = "177-620-3793", Email = "qpadden3@dedecms.com", Mobile = "506-944-1295" },
                new Customer() { ID = 5, FirstName = "Basilius", LastName = "Tesh", Phone = "941-489-2754", Email = "btesh4@nymag.com", Mobile = "500-717-3485" },
                new Customer() { ID = 6, FirstName = "Tommy", LastName = "Jones", Phone = "559-469-2354", Email = "TJ@gmail.com", Mobile = "559-469-3485" }
                );

            modelBuilder.Entity<Address>().HasData(
                new Address() { ID = 1, StreetNumber = "12025", StreetName = "SE 209th St", Unit = "", City = "Kent", Zip = "98031", Country = "USA", CustomerID = 1}

                );
            base.OnModelCreating(modelBuilder);
        }

        internal Customer SingleOrDefault()
        {
            throw new NotImplementedException();
        }
    }
}
