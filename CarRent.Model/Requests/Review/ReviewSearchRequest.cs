using System;
using System.Collections.Generic;
using System.Text;

namespace CarRent.Model.Requests.Review
{
    public class ReviewSearchRequest
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public int NumberOfStars { get; set; }
        public DateTime? DatePosted { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int VehicleId { get; set; }
        public string VehicleName { get; set; }
    }
}
