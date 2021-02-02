using System;
using System.Collections.Generic;
using System.Text;

namespace CarRent.Model.Requests.Rent
{
    public class RentSearchRequest
    {
        public int? RentId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserLastName { get; set; }
        public int VehicleId { get; set; }
        public string VehicleName { get; set; }
        public bool? IsReviewed { get; set; }
        public bool? IsCanceled { get; set; }
        public bool UserRentCount { get; set; }
    }
}
