﻿using System;

namespace CarRent.Model
{
    public class Review
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public int NumberOfStars { get; set; }
        public DateTime DatePosted { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}