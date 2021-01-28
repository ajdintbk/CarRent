using System;
using System.Collections.Generic;
using System.Text;

namespace CarRent.Model.Requests.City
{
    public class CityRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ZipCode { get; set; }
    }
}
