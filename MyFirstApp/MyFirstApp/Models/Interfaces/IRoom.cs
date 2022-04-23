using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstApp.Models.Interfaces
{
    public interface IRoom
    {
        Task<Room> Create(Room h);
        Task<List<Room>> GetStudents();
        Task<Room> GetStudent(int id);
        Task<Room> UpdateStudent(int id, Room student);
        Task Delete(int id);
    }
}
