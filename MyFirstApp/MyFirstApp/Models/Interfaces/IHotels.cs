using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstApp.Models.Interfaces
{
    public interface IHotels
    {
        Task<Hotel> Create(Hotel h);
        Task<List<Hotel>> GetStudents();
        Task<Hotel> GetStudent(int id);
        Task<Hotel> UpdateStudent(int id, Hotel student);
        Task Delete(int id);
    }
}
