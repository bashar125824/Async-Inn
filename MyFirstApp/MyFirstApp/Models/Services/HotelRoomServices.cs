using MyFirstApp.Data;
using MyFirstApp.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstApp.Models.Services
{
    public class HotelRoomServices : IHotelRoom
    {

        private readonly schoolDbContext _context;
        public HotelRoomServices(schoolDbContext context)
        {
            _context = context;
        }
        public async Task<HotelRoom> Create( HotelRoom hr)
        {
            _context.Entry(hr).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return hr;
        }

        public async Task<HotelRoom> GetHotelRoom(int HotelId, int RoomNum)
        {
            return await _context.HotelRooms.Include(hr => hr.roomId)
                                            .Include(hr => hr.hotelId)
                                            .ThenInclude(h => h)
                                            .FirstOrDefaultAsync(x => x.hotelId == HotelId && x.roomNum == RoomNum); 
        }

        public async Task<List<HotelRoom>> GetHotelRooms()
        {
            return await _context.HotelRooms.Include(hr => hr.roomId)
                                            .Include(hr => hr.hotelId)
                                            .ToListAsync(); 
        }

        public async Task<HotelRoom> UpdateHotelRoom(int HotelId, int RoomNum, HotelRoom hr)
        {
            _context.Entry(hr).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return hr;
        }
        public async Task Delete(int HotelId, int RoomNum)
        {
            HotelRoom hr = await GetHotelRoom(HotelId, RoomNum);
            _context.Entry(hr).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

    }
}
