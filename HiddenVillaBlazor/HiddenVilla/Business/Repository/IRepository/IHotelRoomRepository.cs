using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Repository.IRepository
{
   public interface IHotelRoomRepository
   {
      public Task<HotelRoomDto> CreateHotelRoom(HotelRoomDto hotelRoomDto);
      public Task<HotelRoomDto> UpdateHotelRoom(int roomId, HotelRoomDto hotelRoomDto);
      public Task<HotelRoomDto> GetHotelRoom(int roomId);
      public Task<int> DeleteHotelRoom(int roomId);
      public Task<IEnumerable<HotelRoomDto>> GetAllHotelRoom(int roomId);
      public Task<HotelRoomDto> IsRoomUnique(string name);
   }
}
