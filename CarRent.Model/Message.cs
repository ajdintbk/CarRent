using System;
using System.Collections.Generic;
using System.Text;

namespace CarRent.Model
{
    public class Message
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public string Response { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateResponded { get; set; }
        public bool IsOpened { get; set; }
    }
}
