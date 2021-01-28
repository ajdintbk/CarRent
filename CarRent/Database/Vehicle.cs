using System.Collections.Generic;

namespace CarRent.WebApi.Database
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        public int YearManufactured { get; set; }
        public string Transmission { get; set; }
        public int NumberOfSeats { get; set; }
        public bool? IsActive { get; set; }
        public int FuelId { get; set; }
        public virtual Fuel Fuel { get; set; }
        public int VehicleTypeId { get; set; }
        public virtual VehicleType VehicleType { get; set; }
        public int BrandId { get; set; }
        public virtual Brand Brand { get; set; }
        public int VehicleModelId { get; set; }
        public virtual VehicleModel VehicleModel { get; set; }
        public virtual List<Rent> Rents { get; set; }
        public virtual List<Review> Reviews { get; set; }

    }
}