using System;
using System.Collections.Generic;
using System.Text;

namespace CarRent.MobileApp.Models
{
    public enum MenuItemType
    {
        Vehicles,
        Messages,
        About
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
