using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyFirstApp.Models.Interfaces;
using MyFirstApp.Data;
using Microsoft.EntityFrameworkCore;


namespace MyFirstApp.Models.Services
{
    public class HotelServices : IHotels
    {
        private readonly schoolDbContext _context;

        public HotelServices(schoolDbContext context)
        {
            _context = context;
        }


        public async Task<Hotel> Create(Hotel h)
        {
            _context.Entry(h).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return h;
        }

        public async Task<Hotel> GetStudent(int id)
        {
            Hotel hotels = await _context.Hotels.FindAsync(id);

            return hotels;
        }

        public async Task<List<Hotel>> GetStudents()
        {
            var hotels = await _context.Hotels.ToListAsync();
            return hotels;
        }

        public async Task<Hotel> UpdateStudent(int id, Hotel h)
        {
            _context.Entry(h).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return h;
        }

        public async Task Delete(int id)
        {
            Hotel h = await GetStudent(id);

            _context.Entry(h).State = EntityState.Deleted;

            await _context.SaveChangesAsync();


        }

       
    }
}
