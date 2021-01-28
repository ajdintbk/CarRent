using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarRent.Model.Requests
{
    public class AddVehicleRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public byte[] Image { get; set; }
        [Required]
        public double Price { get; set; }
        public string Description { get; set; }
        [Required]
        public int YearManufactured { get; set; }
        [Required]
        public string Transmission { get; set; }
        [Required]
        public int NumberOfSeats { get; set; }
        public bool? IsActive { get; set; }
        public int FuelId { get; set; }
        public int VehicleTypeId { get; set; }
        public int BrandId { get; set; }
        public int VehicleModelId { get; set; }
    }
}
