using System;
using System.Collections.Generic;
using System.Text;

namespace CarRent.Model.ViewModel
{
    public class UserListVM
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public string Role { get; set; }
        public string Status { get; set; }
        public int NumberOfRents { get; set; }
    }
}
