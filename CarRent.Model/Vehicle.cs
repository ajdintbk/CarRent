using System;
using System.Collections.Generic;
using System.Text;

namespace CarRent.Model
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
        //public int FuelId { get; set; }
        public  Fuel Fuel { get; set; }
        //public int VehicleTypeId { get; set; }
        public  VehicleType VehicleType { get; set; }
        //public int BrandId { get; set; }
        public  Brand Brand { get; set; }
        //public int VehicleModelId { get; set; }
        public  VehicleModel VehicleModel { get; set; }
        //public List<Rent> Rents { get; set; }
        //public List<Review> Reviews { get; set; }
    }
}
