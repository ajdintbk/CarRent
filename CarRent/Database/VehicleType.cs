using System.Collections.Generic;

namespace CarRent.WebApi.Database
{
    public class VehicleType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual List<Vehicle> Vehicles { get; set; }
    }
}