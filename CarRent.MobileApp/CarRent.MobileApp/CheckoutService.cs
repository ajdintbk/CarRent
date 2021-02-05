using CarRent.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRent.MobileApp
{
    public static class CheckoutService
    {
        public static Vehicle _vehicle { get; set; }
        public static DateTime _stardDate { get; set; }
        public static DateTime _endDate { get; set; }
        public static bool IsPayed { get; set; }

    }
}
