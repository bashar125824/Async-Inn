using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyFirstApp.Models;

namespace MyFirstApp.Data
{
    public class schoolDbContext : DbContext
    {
       public DbSet<Room> Rooms { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Amenity> Amenities { get; set; }
        public DbSet<HotelRoom> HotelRooms { get; set; }


        public schoolDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // This calls the base method, but does nothing
            // base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Room>().HasData(
              new Room { roomId = 1, nickname = "Special Room" , layout = "master room" },
              new Room { roomId = 2, nickname = "VIP Room" , layout = "Room with a big pool" },
              new Room { roomId = 3, nickname = "Standard Room", layout = "Normal room" }
            );

            modelBuilder.Entity<Hotel>().HasData(

                new Hotel { hotelId = 1 , name = "Sheraton" , city = "Amman" , state = "Amman" , address = "5th Circle" , phoneNum = "0795396245"},
                new Hotel { hotelId = 2, name = "Kempinski", city = "Amman", state = "Amman", address = "Abo Shouman Str", phoneNum = "0784326751" },
                new Hotel { hotelId = 3, name = "Seven Days", city = "Irbid", state = "Irbid", address = "University Str", phoneNum = "0774326571" }

            );

            modelBuilder.Entity<Amenity>().HasData(

               new Amenity {amenityId = 1 , name = "Spa"},
               new Amenity {amenityId = 2 , name = "Toiletries"},
               new Amenity {amenityId = 3, name = "Shaving Cream" }

           );


        }
    }

}
