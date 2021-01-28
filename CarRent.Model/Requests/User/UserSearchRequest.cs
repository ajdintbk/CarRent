using System;
using System.Collections.Generic;
using System.Text;

namespace CarRent.Model.Requests.User
{
    public class UserSearchRequest
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int? RoleId { get; set; }
        public string RoleName { get; set; }
    }
}
