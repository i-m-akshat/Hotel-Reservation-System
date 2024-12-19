using Backend.DataAccessLayer.Context.Models;
using Backend.Models.Country_Domain;
using Backend.Models.Hotel_Domain;
using Backend.Models.State_Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
                //CreatedBy = _hotel.CreatedBy,
                //CreatedDate = _hotel.CreatedDate,
                //UpdatedBy = _hotel.UpdatedBy,
                //UpdatedDate = _hotel.UpdatedDate,
                //DeletedBy = _hotel.DeletedBy,
                //DeletedDate =_hotel.DeletedDate,

            };
        }
        public static Hotel ToHotelWithInclude(this TblHotel _hotel)
        {
            try
            {
                return new Hotel
                {
                    HotelId = _hotel.HotelId,
                    HotelName = _hotel.HotelName,
                    HotelDescription = _hotel.HotelDescription,
                    Address = _hotel.Address,
                    StateId = _hotel.StateId,
                    StateName = _hotel.State.StateName,
                    CountryName = _hotel.Country.CountryName,
                    CityName = _hotel.City.CityName,
                    CountryId = _hotel.CountryId,
                    CityId = _hotel.CityId,
                    IsActive = _hotel.IsActive,
                    CategoryId = _hotel.CategoryId,
                    IconImage = _hotel.IconImage,
                    BannerImage = _hotel.BannerImage,
                    Longitude = _hotel.Longitude,
                    Latitude = _hotel.Latitude,
                    CreatedBy = _hotel.CreatedBy != null ? _hotel.CreatedBy : 0,
                    CreatedDate = _hotel.CreatedDate,
                    UpdatedBy = _hotel.UpdatedBy != null ? _hotel.UpdatedBy : 0,
                    UpdatedDate = _hotel.UpdatedDate,
                    DeletedBy = _hotel.DeletedBy != null ? _hotel.DeletedBy : 0,
                    DeletedDate = _hotel.DeletedDate,

                };
            }
            catch (Exception ex)
            {

                throw;
            }
           
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
                    CreatedBy = _hotel.CreatedBy != null ? _hotel.CreatedBy : 0,
                    CreatedDate = _hotel.CreatedDate,
                    UpdatedBy = _hotel.UpdatedBy != null ? _hotel.UpdatedBy : 0,
                    UpdatedDate = _hotel.UpdatedDate,
                    DeletedBy = _hotel.DeletedBy != null ? _hotel.DeletedBy : 0,
                    DeletedDate = _hotel.DeletedDate,

                };
        }
    }
}
