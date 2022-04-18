using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstApp.Models
{
    public class Hotel
    {
        public int hotelId { set; get; }
        [Required]
        public string name { set; get; }
        public string city { set; get; }
        public string state { set; get; }
        public string address { set; get; }
        public string phoneNum { set; get; }
    }
}
