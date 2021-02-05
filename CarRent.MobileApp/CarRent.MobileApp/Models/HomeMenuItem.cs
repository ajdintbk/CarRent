using System;
using System.Collections.Generic;
using System.Text;

namespace CarRent.MobileApp.Models
{
    public enum MenuItemType
    {
        Browse,
        About,
        Vehicles,
        Messages
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
