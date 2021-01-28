using System;
using System.Collections.Generic;
using System.Text;

namespace CarRent.Model
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ZipCode { get; set; }
        public List<User> Users { get; set; }
    }
}
