using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstApp.Models
{
    public class Amenity
    {

        public int amenityId { get; set; }

        public string name { get; set;
        }

        // Relation is 1 to many
        public List<RoomAmenity> RA { get; set; }
    }
}
