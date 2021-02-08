using Helper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.WebApi.Database
{
    public partial class CarRentContext : DbContext
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=CarRent_rs2;Trusted_Connection=True;MultipleActiveResultSets=True");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<City>(entity =>
            {
                entity.Property(p => p.Name).IsRequired();

                entity.HasMany(d => d.Users)
                       .WithOne(d => d.City)
                       .HasForeignKey(d => d.CityId);
            });

            modelBuilder.Entity<Fuel>(entity => {
                entity.Property(p => p.Name).IsRequired();
                
            });

            modelBuilder.Entity<Brand>(entity => {
                entity.Property(p => p.Name).IsRequired();
                
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

            });

            modelBuilder.Entity<VehicleModel>(entity =>
            {
                entity.Property(p => p.Name).IsRequired();
                
            });

            modelBuilder.Entity<VehicleType>(entity =>
            {
                entity.Property(p => p.Name).IsRequired();
               
            });

            

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);


    }
}
