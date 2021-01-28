using System;
using System.Collections.Generic;
using System.Text;

namespace CarRent.Model.Requests.Vehicle
{
    public class VehicleInsert
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public byte[] Image { get; set; }
        public string Description { get; set; }
        public int YearManufactured { get; set; }
        public string Transmission { get; set; }
        public int NumberOfSeats { get; set; }
        public bool? IsActive { get; set; }
        public int FuelId { get; set; }
        public int VehicleTypeId { get; set; }
        public int BrandId { get; set; }
        public int VehicleModelId { get; set; }

    }
}
