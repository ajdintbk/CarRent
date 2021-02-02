using System;
using System.Collections.Generic;
using System.Text;

namespace CarRent.Model.Requests.Favorites
{
    public class FavoritesInsert
    {
        public int VehicleId { get; set; }
        public int UserId { get; set; }
    }
}
