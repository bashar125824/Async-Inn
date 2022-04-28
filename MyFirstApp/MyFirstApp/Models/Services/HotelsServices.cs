using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyFirstApp.Models.Interfaces;
using MyFirstApp.Data;
using Microsoft.EntityFrameworkCore;
using MyFirstApp.DTO;

namespace MyFirstApp.Models.Services
{
    public class HotelServices : IHotels
    {
        private readonly schoolDbContext _context;

        public HotelServices(schoolDbContext context)
        {
            _context = context;
        }
        public async Task<Hotel> Create(Hotel hotel)
        {
            _context.Entry(hotel).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return hotel;
        }

        public async Task<HotelDTO> GetHotel(int id)
        {
            return await _context.Hotels

              .Select(hotel => new HotelDTO
              {
                  ID = id,
                  Name = hotel.name,
                  Address = hotel.address,
                  City = hotel.city,
                  State = hotel.state,
                  PhoneNumber = hotel.phoneNum,
                  Rooms = hotel.HR
                  .Select(room => new HotelRoomDTO
                  {
                      HotelID = room.h.hotelId,
                      RoomNumber = room.roomNum,
                      Price = room.price,
                      PetFriendly = room.petFriendly,
                      RoomID = room.roomId,
                      r = room.r.layout
                      .Select(r => new RoomDTO
                      {
                          ID = room.r.roomId,
                          Name = room.r.nickname,
                          Layout = room.r.layout,
                          Amenities = room.r.layout
                         .Select(amenity => new AmenityDTO
                         {
                             ID = id,
                           //  Name = amenity..Name,
                         }).ToList()
                      }).FirstOrDefault()
                  }).ToList()
              }).FirstOrDefaultAsync(a => a.ID == id);
        }

        public async Task<List<HotelDTO>> GetHotels()
        {
            return await _context.Hotels

                .Select(hotel => new HotelDTO
                {
                    ID = hotel.hotelId,
                    Name = hotel.name,
                    Address = hotel.address,
                    City = hotel.city,
                    State = hotel.state,
                    PhoneNumber = hotel.phoneNum,
                    Rooms = hotel.HR
                    .Select(room => new HotelRoomDTO
                    {
                        HotelID = room.h.hotelId,
                        RoomNumber = room.roomNum,
                        Price = room.price,
                        PetFriendly = room.petFriendly,
                        RoomID = room.roomId,
                        r = room.h.name
                        .Select(r => new RoomDTO
                        {
                            ID = room.r.roomId,
                            Name = room.r.nickname,
                            Layout = room.r.layout,
                            Amenities = room.r.layout
                           .Select(amenity => new AmenityDTO
                           {
                               //ID = amenity.Id,
                               //Name = amenity.Amenity.Name,
                           }).ToList()
                        }).FirstOrDefault()
                    }).ToList()
                }).ToListAsync();
        }

        public async Task<Hotel> UpdateHotel(int id, Hotel hotel)
        {
            _context.Entry(hotel).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return hotel;
        }
        public async Task Delete(int id)
        {
            Hotel hotel = await _context.Hotels.FindAsync(id);
            _context.Entry(hotel).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }


    }
}
