using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarRent.Model.Requests.Rent
{
    public class RentInsert
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int UserId { get; set; }
        public int VehicleId { get; set; }
        public DateTime DateCreated { get; set; }
        public double TotalPrice { get; set; }
        public bool IsPayed { get; set; }
    }
}
