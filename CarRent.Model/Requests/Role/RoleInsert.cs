using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarRent.Model.Requests.Role
{
    public class RoleInsert
    {
        [Required]
        public string Name { get; set; }
    }
}
