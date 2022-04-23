using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstApp.Models.Interfaces
{
    public interface IAmenity
    {
        Task<Amenity> Create(Hotel h);
        Task<List<Amenity>> GetStudents();
        Task<Amenity> GetStudent(int id);
        Task<Amenity> UpdateStudent(int id, Amenity student);
        Task Delete(int id);
        Task<Amenity> Create(Amenity a);
    }
}
