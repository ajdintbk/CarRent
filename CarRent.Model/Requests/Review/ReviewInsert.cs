using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarRent.Model.Requests.Review
{
    public class ReviewInsert
    {
        public string Comment { get; set; }
        public int NumberOfStars { get; set; }
        public DateTime DatePosted { get; set; }
        public int UserId { get; set; }
        public int VehicleId { get; set; }
    }
}
