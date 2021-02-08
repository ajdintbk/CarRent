using Helper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.WebApi.Database
{
    public partial class CarRentContext
    {
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>().HasData(new List<City>
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
            modelBuilder.Entity<Fuel>().HasData(new List<Fuel>()
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
                    },
                    new Fuel
                    {
                        Id = 3,
                        Name = "Automatic"
                    }
                });
            modelBuilder.Entity<Brand>().HasData(new List<Brand>()
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
                        Name = "Mercedes",
                        ManufacturerUrl = "https://www.mercedes.com/"
                    },
                    new Brand
                    {
                        Id = 4,
                        Name = "Passat",
                        ManufacturerUrl = "https://www.passat.com/"
                    },
                    new Brand
                    {
                        Id = 5,
                        Name = "Porsche",
                        ManufacturerUrl = "https://www.porsche.com/"
                    },
                    new Brand
                    {
                        Id = 6,
                        Name = "Citroen",
                        ManufacturerUrl = "https://www.citroen.com/"
                    }
                });
            modelBuilder.Entity<Role>().HasData(new List<Role>
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
            User user = new User
            {
                Id = 1,
                FirstName = "Ajdin",
                LastName = "Tabak",
                Username = "admin",
                CityId = 1,
                Phone = "062234124",
                Email = "tabakajdin@gmail.com",
                Active = true,
                RoleId = 1
            };
            user.PasswordSalt = HashGenerator.GenerateSalt();
            user.PasswordHash = HashGenerator.GenerateHash(user.PasswordSalt, "admin");

            User user2 = new User
            {
                Id = 2,
                FirstName = "Test",
                LastName = "User",
                Username = "user",
                CityId = 1,
                Phone = "062234124",
                Email = "tabakajdin@gmail.com",
                Active = true,
                RoleId = 2
            };
            user2.PasswordSalt = HashGenerator.GenerateSalt();
            user2.PasswordHash = HashGenerator.GenerateHash(user2.PasswordSalt, "user");

            modelBuilder.Entity<User>().HasData(user);
            modelBuilder.Entity<User>().HasData(user2);

            modelBuilder.Entity<VehicleModel>().HasData(new List<VehicleModel>
                {
                    new VehicleModel
                    {
                        Id = 1,
                        Name = "A6"
                    },
                    new VehicleModel
                    {
                        Id =2,
                        Name = "A7"
                    },
                    new VehicleModel
                    {
                        Id = 3,
                        Name = "530d"
                    },
                    new VehicleModel
                    {
                        Id = 4,
                        Name = "c220"
                    },
                    new VehicleModel
                    {
                        Id = 5,
                        Name = "8"
                    },
                    new VehicleModel
                    {
                        Id = 6,
                        Name = "4S"
                    },
                    new VehicleModel
                    {
                        Id = 7,
                        Name = "C5"
                    }
                });

            modelBuilder.Entity<VehicleType>().HasData(new List<VehicleType> {
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
            modelBuilder.Entity<Vehicle>().HasData(new Vehicle()
            {
                Id = 1,
                Name = "Audi A6",
                Image = File.ReadAllBytes("img/audia6.jpg"),
                Price = 100,
                Description = "Audi A6 3.0 TDI Quattro. Ready for every task.",
                YearManufactured = 2018,
                Transmission = "Automatic",
                NumberOfSeats = 5,
                IsActive = true,
                BrandId = 2,
                FuelId = 1,
                VehicleTypeId = 4,
                VehicleModelId = 1
            });

            // Audi A7 
            modelBuilder.Entity<Vehicle>().HasData(new Vehicle()
            {
                Id = 2,
                Name = "Audi A7",
                Image = File.ReadAllBytes("img/audia7.jpg"),
                Price = 120,
                Description = "Audi A7 3.0 TFSI Quattro. Ready for every task.",
                YearManufactured = 2019,
                Transmission = "Automatic",
                NumberOfSeats = 5,
                IsActive = true,
                BrandId = 2,
                FuelId = 1,
                VehicleTypeId = 4,
                VehicleModelId = 2
            });

            // BMW 530d
            modelBuilder.Entity<Vehicle>().HasData(new Vehicle()
            {
                Id = 3,
                Name = "BMW 530D",
                Image = File.ReadAllBytes("img/bmw.jpg"),
                Price = 90,
                Description = "BMW 530d 258 KS. Ready for every task.",
                YearManufactured = 2017,
                Transmission = "Manual",
                NumberOfSeats = 5,
                IsActive = true,
                BrandId = 1,
                FuelId = 1,
                VehicleTypeId = 1,
                VehicleModelId = 3
            });

            // Mercedes c220
            modelBuilder.Entity<Vehicle>().HasData(new Vehicle()
            {
                Id = 4,
                Name = "Mercedes C220",
                Image = File.ReadAllBytes("img/mercedes.jpg"),
                Price = 100,
                Description = "Mercedes-Benz C220 CDI 170 KS. Ready for every task.",
                YearManufactured = 2016,
                Transmission = "Automatic",
                NumberOfSeats = 5,
                IsActive = true,
                BrandId = 3,
                FuelId = 1,
                VehicleTypeId = 2,
                VehicleModelId = 4
            });

            // Passat 8
            modelBuilder.Entity<Vehicle>().HasData(new Vehicle()
            {
                Id = 5,
                Name = "Passat 8",
                Image = File.ReadAllBytes("img/passat.jfif"),
                Price = 100,
                Description = "Volkswagen Passat 8 170 KS. Ready for every task.",
                YearManufactured = 2019,
                Transmission = "Manual",
                NumberOfSeats = 4,
                IsActive = true,
                BrandId = 4,
                FuelId = 1,
                VehicleTypeId = 4,
                VehicleModelId = 5
            });

            // Porsche 4S
            modelBuilder.Entity<Vehicle>().HasData(new Vehicle()
            {
                Id = 6,
                Name = "Porsche 4S",
                Image = File.ReadAllBytes("img/porsche.jpg"),
                Price = 150,
                Description = "Porsche Carrera 4S 350 KS. Ready for every task.",
                YearManufactured = 2019,
                Transmission = "Automatic",
                NumberOfSeats = 2,
                IsActive = true,
                BrandId = 5,
                FuelId = 2,
                VehicleTypeId = 4,
                VehicleModelId = 6
            });

            // Citroen C5
            modelBuilder.Entity<Vehicle>().HasData(new Vehicle()
            {
                Id = 7,
                Name = "Citroen C5",
                Image = File.ReadAllBytes("img/citroen.jpg"),
                Price = 90,
                Description = "Citroen C5 150 KS. Ready for everyday tasks.",
                YearManufactured = 2016,
                Transmission = "Automatic",
                NumberOfSeats = 5,
                IsActive = true,
                BrandId = 6,
                FuelId = 1,
                VehicleTypeId = 3,
                VehicleModelId = 7
            });

            // BOOKING

            modelBuilder.Entity<Rent>().HasData(new Rent()
            {
                Id = 1,
                StartDate = new DateTime(2021, 02, 14),
                EndDate = new DateTime(2021, 02, 16),
                UserId = 2,
                VehicleId = 1,
                DateCreated = new DateTime(2021, 02, 13),
                IsCanceled = false,
                IsReviewed = true,
                TotalPrice = 200
            });

            modelBuilder.Entity<Rent>().HasData(new Rent()
            {
                Id = 2,
                StartDate = new DateTime(2021, 02, 14),
                EndDate = new DateTime(2021, 02, 17),
                UserId = 2,
                VehicleId = 2,
                DateCreated = new DateTime(2021, 02, 13),
                IsCanceled = false,
                IsReviewed = true,
                TotalPrice = 360
            });

            modelBuilder.Entity<Rent>().HasData(new Rent()
            {
                Id = 3,
                StartDate = new DateTime(2021, 02, 14),
                EndDate = new DateTime(2021, 02, 17),
                UserId = 2,
                VehicleId = 3,
                DateCreated = new DateTime(2021, 02, 13),
                IsCanceled = false,
                IsReviewed = true,
                TotalPrice = 270
            });

            modelBuilder.Entity<Rent>().HasData(new Rent()
            {
                Id = 4,
                StartDate = new DateTime(2021, 02, 14),
                EndDate = new DateTime(2021, 02, 17),
                UserId = 2,
                VehicleId = 4,
                DateCreated = new DateTime(2021, 02, 13),
                IsCanceled = false,
                IsReviewed = true,
                TotalPrice = 300
            });

            modelBuilder.Entity<Rent>().HasData(new Rent()
            {
                Id = 5,
                StartDate = new DateTime(2021, 02, 14),
                EndDate = new DateTime(2021, 02, 17),
                UserId = 2,
                VehicleId = 5,
                DateCreated = new DateTime(2021, 02, 13),
                IsCanceled = false,
                IsReviewed = true,
                TotalPrice = 300
            });

            modelBuilder.Entity<Rent>().HasData(new Rent()
            {
                Id = 6,
                StartDate = new DateTime(2021, 02, 14),
                EndDate = new DateTime(2021, 02, 17),
                UserId = 2,
                VehicleId = 6,
                DateCreated = new DateTime(2021, 02, 13),
                IsCanceled = false,
                IsReviewed = true,
                TotalPrice = 450
            });

            modelBuilder.Entity<Rent>().HasData(new Rent()
            {
                Id = 7,
                StartDate = new DateTime(2021, 02, 14),
                EndDate = new DateTime(2021, 02, 17),
                UserId = 2,
                VehicleId = 7,
                DateCreated = new DateTime(2021, 02, 13),
                IsCanceled = false,
                IsReviewed = true,
                TotalPrice = 270
            });

            modelBuilder.Entity<Review>().HasData(new Review()
            {
                Id = 1,
                Comment = "Audi A6 is fenomenal. I recommend!",
                DatePosted = new DateTime(2021, 02, 20),
                UserId = 2,
                VehicleId = 1,
                NumberOfStars = 5
            });

            modelBuilder.Entity<Review>().HasData(new Review()
            {
                Id = 2,
                Comment = "Audi A7 was mediocre.",
                DatePosted = new DateTime(2021, 02, 20),
                UserId = 2,
                VehicleId = 2,
                NumberOfStars = 3
            });

            modelBuilder.Entity<Review>().HasData(new Review()
            {
                Id = 3,
                Comment = "It was good enough",
                DatePosted = new DateTime(2021, 02, 20),
                UserId = 2,
                VehicleId = 2,
                NumberOfStars = 4
            });

            modelBuilder.Entity<Review>().HasData(new Review()
            {
                Id = 4,
                Comment = "It was good enough",
                DatePosted = new DateTime(2021, 02, 20),
                UserId = 2,
                VehicleId = 3,
                NumberOfStars = 5
            });

            modelBuilder.Entity<Review>().HasData(new Review()
            {
                Id = 5,
                Comment = "Not good enough",
                DatePosted = new DateTime(2021, 02, 20),
                UserId = 2,
                VehicleId = 5,
                NumberOfStars = 2
            });

            modelBuilder.Entity<Review>().HasData(new Review()
            {
                Id = 6,
                Comment = "Good enough. Totally recommend",
                DatePosted = new DateTime(2021, 02, 20),
                UserId = 2,
                VehicleId = 6,
                NumberOfStars = 3
            });

            modelBuilder.Entity<Review>().HasData(new Review()
            {
                Id = 7,
                Comment = "Not satisfied. Car is not doing well",
                DatePosted = new DateTime(2021, 02, 20),
                UserId = 2,
                VehicleId = 7,
                NumberOfStars = 2
            });
        }
    }
}
