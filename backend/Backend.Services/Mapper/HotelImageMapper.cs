using Backend.DataAccessLayer.Context.Models;
using Backend.Models.Hotel_Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Services.Mapper
{
    public static class HotelImageMapper
    {
        public static TblHotelimage ToTblHotelImage(this HotelImage hotelImage)
        {
            return new TblHotelimage()
            {
                HotelId= hotelImage.HotelId,
                HotelImageId= hotelImage.HotelImageId,
                ContentType= hotelImage.ContentType,
                Image= hotelImage.Image,
                Isactive = hotelImage.Isactive,
                ImageName= hotelImage.ImageName,
                
            };
        }
        public static HotelImage ToHotelImage(this TblHotelimage tbl)
        {
            return new HotelImage()
            {
                HotelId = tbl.HotelId,
                HotelImageId = tbl.HotelImageId,
                ContentType = tbl.ContentType,
                Image = tbl.Image,
                Isactive = tbl.Isactive,
                ImageName = tbl.ImageName,
            };
        }
    }
}
