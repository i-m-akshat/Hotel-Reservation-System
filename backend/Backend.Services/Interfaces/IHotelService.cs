using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Models.Hotel_Domain;

namespace Backend.Services.Interfaces
{
    public interface IHotelService
    
    {
        /// <summary>
        /// To add the hotel
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns></returns>
        Task<Hotel> AddHotel(Hotel hotel);
        /// <summary>
        /// To update the hotel
        /// </summary>
        /// <param name="hotel"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Hotel>  UpdateHotel(Hotel hotel,long id);
        /// <summary>
        /// To Delete the hotel
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Hotel> DeleteHotel(long id);
        /// <summary>
        /// To get the hotel by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Hotel> GetHotel(long id);
        /// <summary>
        /// To get all hotels
        /// </summary>
        /// <returns></returns>
        Task<List<Hotel>> GetAllHotel();
    }
}
