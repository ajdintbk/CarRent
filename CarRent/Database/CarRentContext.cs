using Helper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.WebApi.Database
{
    public class CarRentContext : DbContext
    {
        public CarRentContext()
        {
        }

        public CarRentContext(DbContextOptions<CarRentContext> options)
            : base(options)
        {
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<Favorites> Favorites { get; set; }
        public DbSet<Fuel> FuelTypes { get; set; }
        public DbSet<Brand> Manufacturers { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Rent> Rents { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<City>(entity =>
            {
                entity.Property(p => p.Name).IsRequired();

                entity.HasMany(d => d.Users)
                       .WithOne(d => d.City)
                       .HasForeignKey(d => d.CityId);

                entity.HasData(new List<City>
                {
                    new City
                    {
                        Id = 1,
                        Name = "Sarajevo",
                        ZipCode = 71000

                    },
                    new City
                    {
                        Id = 2,
                        Name = "Mostar",
                        ZipCode = 88000
                    },
                    new City
                    {
                        Id = 3,
                        Name = "Tuzla",
                        ZipCode = 75000
                    }
                });

            });

            modelBuilder.Entity<Fuel>(entity => {
                entity.Property(p => p.Name).IsRequired();
                entity.HasData(new List<Fuel>()
                {
                    new Fuel
                    {
                        Id = 1,
                        Name = "Dizel"
                    },
                    new Fuel
                    {
                        Id = 2,
                        Name = "Benzin"
                    }
                });
            });

            modelBuilder.Entity<Brand>(entity => {
                entity.Property(p => p.Name).IsRequired();
                entity.HasData(new List<Brand>()
                {
                    new Brand
                    {
                        Id = 1,
                        Name = "BMW",
                        ManufacturerUrl = "https://www.bmw.com/en/index.html"
                    },
                    new Brand
                    {
                        Id = 2,
                        Name = "Audi",
                        ManufacturerUrl = "https://www.audi.com/en.html"
                    },
                    new Brand
                    {
                        Id = 3,
                        Name = "Fiat",
                        ManufacturerUrl = "https://www.fiat.com/"
                    }
                });
            });

            modelBuilder.Entity<Review>(entity => {
                entity.Property(p => p.Comment).IsRequired();
                entity.Property(p => p.NumberOfStars).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(d => d.Reviews)
                    .HasForeignKey(d => d.UserId);

                entity.HasOne(d => d.Vehicle)
                    .WithMany(d => d.Reviews)
                    .HasForeignKey(d => d.VehicleId);

            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(p => p.Name).IsRequired();
                entity.HasData(new List<Role>
                {
                    new Role
                    {
                        Id = 1,
                        Name = "Administrator"
                    },
                    new Role
                    {
                        Id = 2,
                        Name="User"
                    }
                });
            });

            modelBuilder.Entity<Rent>(entity =>
            {
                entity.HasOne(d => d.User)
                    .WithMany(p => p.Rents)
                    .HasForeignKey(d => d.UserId);

                entity.HasOne(d => d.Vehicle)
                    .WithMany(p => p.Rents)
                    .HasForeignKey(d => d.VehicleId);
            });

            modelBuilder.Entity<User>(entity => {
                entity.Property(p => p.FirstName).IsRequired();
                entity.Property(p => p.LastName).IsRequired();
                entity.Property(p => p.Username).IsRequired();
                entity.Property(p => p.Email).IsRequired();

                User user = new User
                {
                    Id = 1,
                    FirstName = "Ajdin",
                    LastName = "Tabak",
                    Username = "ajdintbk",
                    CityId = 1,
                    Phone = "062234124",
                    Email = "tabakajdin@gmail.com",
                };
                user.PasswordSalt = HashGenerator.GenerateSalt();
                user.PasswordHash = HashGenerator.GenerateHash(user.PasswordSalt, "ajdin123");

                modelBuilder.Entity<User>().HasData(user);

                
            });

            modelBuilder.Entity<VehicleModel>(entity =>
            {
                entity.Property(p => p.Name).IsRequired();
                entity.HasData(new List<VehicleModel>
                {
                    new VehicleModel
                    {
                        Id = 1,
                        Name = "A4"
                    },
                    new VehicleModel
                    {
                        Id =2,
                        Name = "Q7"
                    },
                    new VehicleModel
                    {
                        Id = 3,
                        Name = "500X"
                    }
                });
            });

            modelBuilder.Entity<VehicleType>(entity =>
            {
                entity.Property(p => p.Name).IsRequired();
                entity.HasData(new List<VehicleType> {
                    new VehicleType
                    {
                        Id = 1,
                        Name = "Sedan"
                    },
                    new VehicleType
                    {
                        Id = 2,
                        Name = "SUV"
                    },
                    new VehicleType
                    {
                        Id = 3,
                        Name = "Convertible"
                    },
                    new VehicleType
                    {
                        Id = 4,
                        Name = "Sports Car"
                    },

                });
            });
        }


    }
}
