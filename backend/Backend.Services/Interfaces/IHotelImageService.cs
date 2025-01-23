using Backend.DataAccessLayer.Context.Models;
using Backend.Models.Hotel_Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Services.Interfaces
{
   public interface IHotelImageService
    {
       Task<HotelImage>  GetHotelImage(long imageId);
       Task<List<HotelImage>>  GetAll();
       Task<HotelImage> CreateHotelImage(HotelImage hotelImage);
       Task<HotelImage> UpdateHotelImage(long imageId,HotelImage hotelImage);
       Task<HotelImage> DeleteHotelImage(long imageId);
       Task<List<HotelImage>> GetHotelImagesByHotelId(long hotelId);


    }
}
