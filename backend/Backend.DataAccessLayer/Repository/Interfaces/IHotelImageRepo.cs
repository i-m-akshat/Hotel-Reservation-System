using Backend.DataAccessLayer.Context.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.DataAccessLayer.Repository.Interfaces
{
    public interface IHotelImageRepo
    {
        /// <summary>
        /// To get all images in database
        /// </summary>
        /// <returns></returns>
        Task<List<TblHotelimage>> GetAllImages();
        /// <summary>
        /// To get the image by id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TblHotelimage> GetImageById(long id);
        /// <summary>
        /// To get all the images of a particular hotel
        /// </summary>
        /// <param name="Hotelid"></param>
        /// <returns></returns>
        Task<List<TblHotelimage>> GetImages_HotelID(long Hotelid);
        /// <summary>
        /// To add the image of hotel
        /// </summary>
        /// <param name="tblHotelImage"></param>
        /// <returns></returns>
        Task<TblHotelimage> AddHotelImage( TblHotelimage tblHotelImage);
        /// <summary>
        /// To Update the hotel image
        /// </summary>
        /// <param name="id"></param>
        /// <param name="tblHotelImage"></param>
        /// <returns></returns>
        Task<TblHotelimage> UpdateHotelImage(long id, TblHotelimage tblHotelImage);
        /// <summary>
        /// To delete the hotel image
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TblHotelimage> DeleteHotelImage(long id);
    }
}
