using System;
using System.Collections.Generic;
using System.Text;

namespace CarRent.Model.Requests.Message
{
    public class MessageSearchRequest
    {
        public int Id { get; set; }
        public string Question { get; set; }
        public string Response { get; set; }
        public string UserName { get; set; }
        public int UserId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateResponded { get; set; }
        public int IsOpened { get; set; }
    }
}
