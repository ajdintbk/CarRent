using System;

namespace CarRent.Model
{
    public class Rent
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
        public DateTime DateCreated { get; set; }
        public double TotalPrice { get; set; }
        public bool IsReviewed { get; set; }
        public bool IsCanceled { get; set; }
    }
}