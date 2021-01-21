using BikeService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeService.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Bike> Bikes { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bike>().HasData(new Bike
            {
                Id = Guid.Parse("d719c835-ce3e-4dad-ad64-cfec54b19775"),
                Brand = "Giant",
                Model = "TCR",
                Size = 54,
                Description = "Repair front wheel",
                CustomerID = Guid.Parse("65da4ed0-35b9-454e-b5ac-d0eee7aad646"),
                AddedBike = new DateTime(2020, 11, 28)
            },
            new Bike
            {
                Id = Guid.Parse("e6e46660-bb84-451d-aafe-a6c7346a48ae"),
                Brand = "Kross",
                Model = "Vento 5.0",
                Size = 58,
                Description = "Change Casette",
                CustomerID = Guid.Parse("65da4ed0-35b9-454e-b5ac-d0eee7aad646"),
                AddedBike = new DateTime(2020, 7, 15)
            },
            new Bike
            {
                Id = Guid.Parse("99289c1a-3342-40fc-905b-65c2dd59babe"),
                Brand = "Merida",
                Model = "Reacto 4000",
                Size = 56,
                Description = "Change chain",
                CustomerID = Guid.Parse("65da4ed0-35b9-454e-b5ac-d0eee7aad646"),
                AddedBike = new DateTime(2020, 8, 21)
            });

            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                Id = Guid.Parse("9a7d64d6-b3f4-42da-90cc-e616c3afdc7b"),
                Name = "Johon",
                Surname = "Wallie",
                Email = "john@gmail.com",
                TelephoneNumber = "123456789",
                DateTimeAdd = new DateTime(2020, 7, 13)
            },
            new Customer
            {
                Id = Guid.Parse("3c7ddfb9-cfb4-4b97-a95a-8510ecb707d1"),
                Name = "Mark",
                Surname = "Tree",
                Email = "mark@gmail.com",
                TelephoneNumber = "234567891",
                DateTimeAdd = new DateTime(2020, 4, 11)
            },
            new Customer
            {
                Id = Guid.Parse("65da4ed0-35b9-454e-b5ac-d0eee7aad646"),
                Name = "Peter",
                Surname = "Kowalsky",
                Email = "peter@gmail.com",
                TelephoneNumber = "434567891",
                DateTimeAdd = new DateTime(2020, 2, 25)
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
