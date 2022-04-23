using Microsoft.EntityFrameworkCore;
using MyFirstApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstApp.Models.Services
{
    public class AmenitiesServices
    {
        private readonly schoolDbContext _context;

        public AmenitiesServices(schoolDbContext context)
        {
            _context = context;
        }


        public async Task<Amenity> Create(Amenity a)
        {
            _context.Entry(a).State = EntityState.Added;
            await _context.SaveChangesAsync();
            return a;
        }

        public async Task<Amenity> GetStudent(int id)
        {
            Amenity amenities = await _context.Amenities.FindAsync(id);

            return amenities;
        }

        public async Task<List<Amenity>> GetStudents()
        {
            var amenities = await _context.Amenities.ToListAsync();
            return amenities;
        }

        public async Task<Amenity> UpdateStudent(int id, Amenity a)
        {
            _context.Entry(a).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return a;
        }

        public async Task Delete(int id)
        {
            Amenity a = await GetStudent(id);

            _context.Entry(a).State = EntityState.Deleted;

            await _context.SaveChangesAsync();


        }
    }
}
