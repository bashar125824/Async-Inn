using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstApp.Models
{
    public class HotelRoom
    {
        public int hotelRoomId { get; set; }
        public int roomNum { get; set; }
        public int price { get; set; }
        public int hotelId { get; set; }
        public int roomId { get; set; }
        public bool petFriendly { get; set; }

        // Navigation 
        public Hotel h { get; set; }
        public Room r { get; set; }
    }
}
