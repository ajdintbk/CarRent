using System.Collections.Generic;

namespace CarRent.WebApi.Database
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string PasswordSalt { get; set; }
        public string PasswordHash { get; set; }
        public int? CityId { get; set; }
        public City City { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public bool Active { get; set; }
        public List<Rent> Rents { get; set; }
        public List<Review> Reviews { get; set; }

    }
}