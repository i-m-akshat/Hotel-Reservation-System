using Backend.DataAccessLayer.Context.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.DataAccessLayer.Repository.Interfaces
{
   public interface IHotelRepo
    {
        public Task< List<TblHotel>> GetAllHotels();
        public Task<TblHotel> GetHotelsByid(long id);
        public Task<TblHotel> CreateHotel(TblHotel hotel);  
        public Task<TblHotel> DeleteHotel(long id);
        public Task<TblHotel> UpdateHotel(TblHotel hotel,long id);
    }
}
