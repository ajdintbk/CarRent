using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarRent.Model.ViewModel
{
    public class ReviewListVM
    {
        public string Comment { get; set; }
        [Display(Name ="Number of stars")]
        public string NumberOfStars { get; set; }
        [Display(Name = "By user")]
        public string Username { get; set; }
        [Display(Name ="Date commented")]
        public string DatePosted { get; set; }

    }
}
