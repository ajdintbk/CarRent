using System.Collections.Generic;

namespace CarRent.WebApi.Database
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ManufacturerUrl { get; set; }
        public virtual List<Vehicle> Vehicles { get; set; }

    }
}