using Backend.DataAccessLayer.Context.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.DataAccessLayer.Repository.Interfaces
{
    public interface IHotelContactRepo
    {
        /// <summary>
     /// Get All Hotel Contact
     /// </summary>
     /// <returns></returns>
        public Task<List<TblHotelcontactdetail>> GetAllHotels();
        /// <summary>
        /// Get Hotel By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<TblHotelcontactdetail> GetHotelContactsByid(long id);
        /// <summary>
        /// To Add the Hotel contact
        /// </summary>
        /// <param name="hotelcontactdetail"></param>
        /// <returns></returns>
        public Task<TblHotelcontactdetail> CreateHotelContact(TblHotelcontactdetail hotelcontactdetail);
        /// <summary>
        /// To Delete the Hotel contact
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<TblHotelcontactdetail> DeleteHotelContact(long id);
        /// <summary>
        /// To update the hotelcontact
        /// </summary>
        /// <param name="hotelcontactdetail"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<TblHotelcontactdetail> UpdateHotel(TblHotelcontactdetail hotelcontactdetail, long id);
        /// <summary>
        /// Gets the hotel contact details based on the hotel id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<List<TblHotelcontactdetail>> GetHotelContactDetailsByHotelId(long id);
    }
}
