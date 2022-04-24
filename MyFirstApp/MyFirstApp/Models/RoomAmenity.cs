using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstApp.Models
{
    public class RoomAmenity
    {
        public int roomAmenetiesId { get; set; }
        public int roomId { get; set; }
        public int amenityId { get; set; }

        //Navigation 
        public Amenity A { get; set; }
        public Room R { get; set; }
    }
}
