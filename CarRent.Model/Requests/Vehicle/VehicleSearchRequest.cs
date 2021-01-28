using System;
using System.Collections.Generic;
using System.Text;

namespace CarRent.Model.Requests.Vehicle
{
    public class VehicleSearchRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int YearManufactured { get; set; }
        public string Transmission { get; set; }
        public int NumberOfSeats { get; set; }
        public bool? IsActive { get; set; }
        public int FuelId { get; set; }
        public string Fuel { get; set; }
        public int VehicleTypeId { get; set; }
        public string VehicleType { get; set; }
        public int BrandId { get; set; }
        public string Brand { get; set; }
        public int VehicleModelId { get; set; }
        public string VehicleModel { get; set; }

    }
}
