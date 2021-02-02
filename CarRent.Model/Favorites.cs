using System;
using System.Collections.Generic;
using System.Text;

namespace CarRent.Model
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
