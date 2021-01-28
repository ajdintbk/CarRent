using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarRent.Model.ViewModel
{
    public class RentListItemVM
    {
        public int RentId { get; set; }
        [Display(Name = "User")]
        public string Username { get; set; }
        public string VehicleName { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public string TotalPrice { get; set; }
    }
}
