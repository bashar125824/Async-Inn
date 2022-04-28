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
    public class AmenitiesServices
    {
        public class AmenityServieces : IAmenity
        {
            private readonly schoolDbContext _context;

            public AmenityServieces(schoolDbContext context)
            {
                _context = context;
            }
            public async Task<AmenityDTO> Create(AmenityDTO amenitydto)
            {
                Amenity amenities = new Amenity
                {
                    amenityId = amenitydto.ID,
                    name = amenitydto.Name,
                };
                _context.Entry(amenities).State = EntityState.Added;
                await _context.SaveChangesAsync();
                return amenitydto;
            }

            public async Task<AmenityDTO> GetAmenity(int id)
            {
                return await _context.Amenities

                   .Select(amenity => new AmenityDTO 
                   {
                       ID = id,
                       Name = amenity.name,
                   }).FirstOrDefaultAsync(a => a.ID == id); // one amenity
            }

            public async Task<List<AmenityDTO>> GetAmenities()
            {
                return await _context.Amenities

                 .Select(amenity => new AmenityDTO 
                 {
                     ID = amenity.amenityId,
                     Name = amenity.name,
                 }).ToListAsync();
            }

            public async Task<AmenityDTO> UpdateAmenity(int id, AmenityDTO amenitydto)
            {
                Amenity amenities = new Amenity
                {
                    amenityId = amenitydto.ID,
                    name = amenitydto.Name,
                };
                _context.Entry(amenities).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return amenitydto;
            }
            public async Task Delete(int id)
            {
                Amenity amenity = await _context.Amenities.FindAsync(id);
                _context.Entry(amenity).State = EntityState.Deleted;
                await _context.SaveChangesAsync();
            }
        }
    }
}
