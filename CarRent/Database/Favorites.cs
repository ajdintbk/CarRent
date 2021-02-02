using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.WebApi.Database
{
    public class Favorites
    {
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
