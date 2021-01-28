using System.Collections.Generic;

namespace CarRent.WebApi.Database
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ZipCode { get; set; }
        public List<User> Users{ get; set; }
    }
}