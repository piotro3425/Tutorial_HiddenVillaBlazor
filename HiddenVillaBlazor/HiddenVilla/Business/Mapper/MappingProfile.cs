using AutoMapper;
using DataAcess.Data;
using Models;

namespace Business.Mapper
{
   public class MappingProfile : Profile
   {
      public MappingProfile()
      {
         CreateMap<HotelRoomDto, HotelRoom>();
         CreateMap<HotelRoom, HotelRoomDto>();
      }
   }
}
