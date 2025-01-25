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
        public static TblHotelimage ToTblHotelImage_Context(this HotelImage hotelImage)
        {
            return new TblHotelimage()
            {
                HotelId = hotelImage.HotelId,
                Hotel= 
                {
                    HotelId = hotelImage.HotelId.Value,
                    HotelName = hotelImage.HotelName,
                },
                HotelImageId = hotelImage.HotelImageId,
                ContentType = hotelImage.ContentType,
                Image = hotelImage.Image,
                Isactive = hotelImage.Isactive,
                ImageName = hotelImage.ImageName,

            };
        }
        public static HotelImage ToHotelImage(this TblHotelimage tbl)
        {
            return new HotelImage()
            {
                HotelId = tbl.HotelId,
                HotelName=tbl.Hotel.HotelName,
                HotelImageId = tbl.HotelImageId,
                ContentType = tbl.ContentType,
                Image = tbl.Image!=null?tbl.Image:null,
                Isactive = tbl.Isactive,
                ImageName = tbl.ImageName,
            };
        }
        public static HotelImage ToHotelImage_ExcludingHotel(this TblHotelimage tbl)
        {
            return new HotelImage()
            {
                HotelId = tbl.HotelId,
                //HotelName = tbl.Hotel.HotelName,
                HotelImageId = tbl.HotelImageId,
                ContentType = tbl.ContentType,
                Image = tbl.Image != null ? tbl.Image : null,
                Isactive = tbl.Isactive,
                ImageName = tbl.ImageName,
            };
        }
    }
}
