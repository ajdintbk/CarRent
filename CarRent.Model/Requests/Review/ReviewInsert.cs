using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarRent.Model.Requests.Review
{
    public class ReviewInsert
    {
        [Required]
        public string Comment { get; set; }
        [Required]
        public int NumberOfStars { get; set; }
        public DateTime DatePosted { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public int VehicleId { get; set; }
    }
}
