using MyFirstApp.Data;
using MyFirstApp.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyFirstApp.DTO;

namespace MyFirstApp.Models.Interfaces
{
    
        public interface IHotelRoom
        {
        Task<HotelRoomDTO> Create(HotelRoomDTO hotelRoom);
        Task<List<HotelRoomDTO>> GetHotelRooms();
      
        Task<HotelRoomDTO> GetHotelRoom(int HotelId, int RoomNum);
        Task<HotelRoomDTO> UpdateHotelRoom(int HotelId, int RoomNum, HotelRoomDTO hotelRoom);
        Task Delete(int HotelId, int RoomNum);
        
    }

}
    
