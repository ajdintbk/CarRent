using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CarRent.Model.Requests.Message
{
    public class MessageInsert
    {
        [Required]
        public string Question { get; set; }
        public string Response { get; set; }
        [Required]
        public int UserId { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateResponded { get; set; }
        public bool IsOpened { get; set; }
    }
}
