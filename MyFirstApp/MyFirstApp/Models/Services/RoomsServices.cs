using Microsoft.EntityFrameworkCore;
using MyFirstApp.Data;
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


        public async Task<Room> Create(Room r)
        {
            _context.Entry(r).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return r;
        }

        public async Task<Room> GetStudent(int id)
        {
            Room rooms = await _context.Rooms.FindAsync(id);

            return rooms;
        }

        public async Task<List<Room>> GetStudents()
        {
            var rooms = await _context.Rooms.ToListAsync();
            return rooms;
        }

        public async Task<Room> UpdateStudent(int id, Room r)
        {
            _context.Entry(r).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return r;
        }

        public async Task Delete(int id)
        {
            Room r = await GetStudent(id);

            _context.Entry(r).State = EntityState.Deleted;

            await _context.SaveChangesAsync();


        }

        internal object Entry(Hotel hotel)
        {
            throw new NotImplementedException();
        }
    }
}
