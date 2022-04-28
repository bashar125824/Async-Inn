using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstApp.DTO
{
    public class HotelRoomDTO
    {
        
       
            public int HotelRoomID { get; set; }
            public int RoomNumber { get; set; }
            public decimal Price { get; set; }
            public bool PetFriendly { get; set; }
            public int RoomID { get; set; }

            public int HotelID { get; set; }
        
            public RoomDTO r { get; set; }
        
    }

}
