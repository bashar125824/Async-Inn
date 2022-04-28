using Microsoft.EntityFrameworkCore;
using MyFirstApp.Data;
using MyFirstApp.DTO;
using MyFirstApp.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstApp.Models.Services
{
    public class RoomsServices : IRoom
    {

        private readonly schoolDbContext _context;

        public RoomsServices(schoolDbContext context)
        {
            _context = context;
        }
        public async Task<RoomDTO> Create(RoomDTO room)
        {
            Room room1 = new Room
            {
                roomId = room.ID,
                nickname = room.Name,
                layout = room.Layout
            };
            _context.Entry(room1).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return room;
        }

        public async Task<RoomDTO> GetRoom(int id)
        {
            return await _context.Rooms

               .Select(room => new RoomDTO
               {
                   ID = id,
                   Name = room.nickname,
                   Layout = room.layout,
                   Amenities = room.layout
                    .Select(amenity => new AmenityDTO
                    {
                        ID = id,
                       // Name = amenity.,
                    }).ToList()
               }).FirstOrDefaultAsync(a => a.ID == id);
        }


        public async Task<List<RoomDTO>> GetRooms()
        {
            return await _context.Rooms

                .Select(room => new RoomDTO
                {
                    ID = room.roomId,
                    Name = room.nickname,
                    Layout = room.layout,
                    Amenities = room.layout
                     .Select(amenity => new AmenityDTO
                     {
                         ID = room.roomId,
                        // Name = amenity.Room.Name,
                     }).ToList()
                }).ToListAsync();
        }

        public async Task<RoomDTO> UpdateRoom(int id, RoomDTO room)
        {
            Room room1 = new Room
            {
                roomId = room.ID,
                nickname = room.Name,
                layout = room.Layout
            };
            _context.Entry(room1).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return room;
        }
        public async Task Delete(int id)
        {
            Room room = await _context.Rooms.FindAsync(id);
            _context.Entry(room).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
        public async Task AddAmenityToRoom(int roomId, int amenityId)
        {
            RoomAmenity amenity = new RoomAmenity()
            {
                amenityId = amenityId,
                roomId = roomId
            };
            _context.Entry(amenity).State = EntityState.Added; // because we are creating a new one
            await _context.SaveChangesAsync();
        }
        public async Task RemoveAmenityFromRoom(int roomId, int amenityId)
        {
            var removedAmenity = await _context.Amenities.FirstOrDefaultAsync(a =>  a.amenityId == amenityId);
            _context.Amenities.Remove(removedAmenity);
            await _context.SaveChangesAsync();
        }
    }
}
