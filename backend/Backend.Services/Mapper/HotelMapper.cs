using Backend.DataAccessLayer.Context.Models;
using Backend.Models.Hotel_Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Services.Mapper
{
    public static class HotelMapper
    {
        public static TblHotel ToTblHotel(this Hotel _hotel)
        {
            return new TblHotel
            {
                HotelId = _hotel.HotelId,
                HotelName = _hotel.HotelName,
                HotelDescription = _hotel.HotelDescription,
                Address = _hotel.Address,
                StateId = _hotel.StateId,
                CountryId = _hotel.CountryId,
                CityId = _hotel.CityId,
                IsActive = _hotel.IsActive,
                CategoryId = _hotel.CategoryId,
                IconImage = _hotel.IconImage,
                BannerImage = _hotel.BannerImage,
                Longitude = _hotel.Longitude,
                Latitude = _hotel.Latitude,

            };
        }
        public static Hotel ToHotel(this TblHotel _hotel)
        {
            return new Hotel
            {
                HotelId = _hotel.HotelId,
                HotelName = _hotel.HotelName,
                HotelDescription = _hotel.HotelDescription,
                Address = _hotel.Address,
                StateId = _hotel.StateId,
                CountryId = _hotel.CountryId,
                CityId = _hotel.CityId,
                IsActive = _hotel.IsActive,
                CategoryId = _hotel.CategoryId,
                IconImage = _hotel.IconImage,
                BannerImage = _hotel.BannerImage,
                Longitude = _hotel.Longitude,
                Latitude = _hotel.Latitude,
                
            };
        }
    }
}
