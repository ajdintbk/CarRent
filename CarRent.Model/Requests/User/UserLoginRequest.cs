using System;
using System.Collections.Generic;
using System.Text;

namespace CarRent.Model.Requests.User
{
    public class UserLoginRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
