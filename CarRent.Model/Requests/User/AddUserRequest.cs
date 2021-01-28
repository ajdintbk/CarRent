using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarRent.Model.Requests
{
    public class AddUserRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }  
        public string Password { get; set; }
        public string PasswordConfirmation { get; set; }
        public int CityId { get; set; }
        public int RoleId { get; set; }
        public bool Active { get; set; }
    }
}
