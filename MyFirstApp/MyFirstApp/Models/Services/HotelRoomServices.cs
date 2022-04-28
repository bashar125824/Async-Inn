using MyFirstApp.Data;
using MyFirstApp.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyFirstApp.DTO;

namespace MyFirstApp.Models.Services
{
    public class HotelRoomServices : IHotelRoom
    {

        private readonly schoolDbContext _context;
        public HotelRoomServices(schoolDbContext context)
        {
            _context = context;
        }
        public async Task<HotelRoomDTO> Create(HotelRoomDTO hotelRoom)
        {
            HotelRoom hr = new HotelRoom
            {
                hotelRoomId = hotelRoom.HotelRoomID,
                roomNum = hotelRoom.RoomNumber,
                roomId = hotelRoom.RoomID,
                price = (int)hotelRoom.Price,
                petFriendly = hotelRoom.PetFriendly,
                hotelId = hotelRoom.HotelID

            };
            _context.Entry(hr).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return hotelRoom;
        }
        public async Task<HotelRoomDTO> GetHotelRoom(int HotelId, int RoomNum)
        {
            return await _context.HotelRooms
                                 .Select(hr => new HotelRoomDTO()
                                 {
                                     HotelID = hr.hotelId,
                                     RoomNumber = hr.roomNum,
                                     Price = hr.price,
                                     PetFriendly = hr.petFriendly,
                                     RoomID = hr.roomId,
                                     r = new RoomDTO()
                                     {
                                         ID = hr.r.roomId,
                                         Name = hr.r.nickname,
                                         Layout = hr.r.layout,
                                         Amenities = hr.r.layout
                                         .Select(amenity => new AmenityDTO
                                         {
                                             //ID = amenity..Id,
                                             //Name = amenity.Amenity.Name,
                                         }).ToList()
                                     }
                                 }).FirstOrDefaultAsync(x => x.HotelID == HotelId && x.RoomNumber == RoomNum);

        }

        public async Task<List<HotelRoomDTO>> GetHotelRooms()
        {
            return await _context.HotelRooms
                               .Select(hr => new HotelRoomDTO()
                               {
                                   HotelID = hr.hotelId,
                                   RoomNumber = hr.roomNum,
                                   Price = hr.price,
                                   PetFriendly = hr.petFriendly,
                                   RoomID = hr.roomId,
                                   HotelRoomID = hr.hotelRoomId,
                                   r = new RoomDTO()
                                   {
                                       ID = hr.r.roomId,
                                       Name = hr.r.nickname,
                                       Layout = hr.r.layout,
                                      Amenities = hr.r.layout
                                       .Select(amenity => new AmenityDTO
                                     {
                                      //    ID = amenity.Id,
                                       //    Name = amenity.Amenity.Name,
                                      }).ToList()
                                  }
                               }).ToListAsync();

        }

        public async Task<HotelRoomDTO> UpdateHotelRoom(int HotelId, int RoomNum, HotelRoomDTO hr)
        {
            HotelRoom hotelRoom = new HotelRoom
            {
                hotelId = hr.HotelID,
                roomNum = hr.RoomNumber,
                price = (int)hr.Price,
                petFriendly = hr.PetFriendly,
                roomId = hr.RoomID,
                hotelRoomId = hr.HotelRoomID,
            };
            _context.Entry(hr).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return hr;
        }
        public async Task Delete(int HotelId, int RoomNum)
        {
            HotelRoom hotelRoom = await _context.HotelRooms.FindAsync(HotelId, RoomNum);
            _context.Entry(hotelRoom).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

    }
}
