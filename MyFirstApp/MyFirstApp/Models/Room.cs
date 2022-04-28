using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstApp.Models
{
    public class Room
    {

        public int roomId { set; get; }
        public string nickname { set; get; }
        public string layout { set; get; }

        // Relation is one to many , so add Navigation property as a list
        public HotelRoom HR { get; set; }
        public List<RoomAmenity> RA { get; set; }

        public enum Layout
        {
            Master ,
            VIP ,
            Standard
        }
    }
}
