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
        /// <summary>
        /// Get All Hotels
        /// </summary>
        /// <returns></returns>
        public Task< List<TblHotel>> GetAllHotels();
        /// <summary>
        /// Get Hotel By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<TblHotel> GetHotelsByid(long id);
        /// <summary>
        /// To Add the Hotel
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns></returns>
        public Task<TblHotel> CreateHotel(TblHotel hotel);  
        /// <summary>
        /// To Delete the Hotel
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<TblHotel> DeleteHotel(long id);
        /// <summary>
        /// To update the hotel
        /// </summary>
        /// <param name="hotel"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<TblHotel> UpdateHotel(TblHotel hotel,long id);
    }
}
