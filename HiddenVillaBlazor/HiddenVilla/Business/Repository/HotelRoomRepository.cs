using AutoMapper;
using Business.Repository.IRepository;
using DataAcess.Data;
using Microsoft.EntityFrameworkCore;
using Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Repository
{
   public class HotelRoomRepository : IHotelRoomRepository
   {
      private readonly ApplicationDbContext db;
      private readonly IMapper mapper;

      public HotelRoomRepository(ApplicationDbContext db, IMapper mapper)
      {
         this.db = db;
         this.mapper = mapper;
      }

      public async Task<HotelRoomDto> CreateHotelRoom(HotelRoomDto hotelRoomDto)
      {
         HotelRoom hotelRoom = mapper.Map<HotelRoomDto, HotelRoom>(hotelRoomDto);
         hotelRoom.CreatedDate = DateTime.Now;
         hotelRoom.CreatedBy = "";
         var addedHotelRoom = await db.HotelRoms.AddAsync(hotelRoom);
         await db.SaveChangesAsync();

         return mapper.Map<HotelRoom, HotelRoomDto>(addedHotelRoom.Entity);
      }

      public async  Task<int> DeleteHotelRoom(int roomId)
      {
         var roomDetails = await db.HotelRoms.FindAsync(roomId);
         if(roomDetails != null)
         {
            db.Remove(roomDetails);
            return await db.SaveChangesAsync();
         }

         return 0;
      }

      public async Task<IEnumerable<HotelRoomDto>> GetAllHotelRoom()
      {
         try
         {
            IEnumerable<HotelRoomDto> hotelRoomDtos = mapper.Map<IEnumerable<HotelRoom>, IEnumerable<HotelRoomDto>>(db.HotelRoms);
            return hotelRoomDtos;
         }
         catch(Exception)
         {
            return null;
         }
      }

      public async Task<HotelRoomDto> GetHotelRoom(int roomId)
      {
         try
         {
            HotelRoomDto hotelRoomDto = mapper.Map<HotelRoom, HotelRoomDto>(await db.HotelRoms.FirstOrDefaultAsync(x => x.Id == roomId));
            return hotelRoomDto;
         }
         catch(Exception)
         {
            return null;
         }
      }

      //if unique returns null else returns the room obj
      public async Task<HotelRoomDto> IsRoomUnique(string name)
      {
         try
         {
            HotelRoomDto hotelRoomDto = mapper.Map<HotelRoom, HotelRoomDto>(await db.HotelRoms.FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower()));
            return hotelRoomDto;
         }
         catch (Exception)
         {
            return null;
         }
      }

      public async Task<HotelRoomDto> UpdateHotelRoom(int roomId, HotelRoomDto hotelRoomDto)
      {
         try
         {
            if (roomId == hotelRoomDto.Id)
            {
               HotelRoom roomDetails = await db.HotelRoms.FindAsync(roomId);
               HotelRoom room = mapper.Map<HotelRoomDto, HotelRoom>(hotelRoomDto, roomDetails);
               room.UpdatedBy = "";
               room.UpdatedDate = DateTime.Now;
               var updatedRoom = db.HotelRoms.Update(room);
               await db.SaveChangesAsync();

               return mapper.Map<HotelRoom, HotelRoomDto>(updatedRoom.Entity);
            }
            else
            {
               return null;
            }
         }
         catch(Exception)
         {
            return null;
         }
      }
   }
}
