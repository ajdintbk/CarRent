using System;
using System.Collections.Generic;
using System.Text;

namespace CarRent.Model.ViewModel
{
    public class VehicleListVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string Description { get; set; }
        public int YearManufactured { get; set; }
        public string Transmission { get; set; }
        public int NumberOfSeats { get; set; }
        public bool IsActive { get; set; }
        public string Fuel { get; set; }
        public string Brand { get; set; }
        public string VehicleModel { get; set; }
    }
}
