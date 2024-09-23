using Frontend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelReservationSystem_Part1.Mapper
{
    public static class UserMapper
    {

        public static User ToUserModelFromDTO(this User _user)
        {
            return new User
            {
                FullName = _user.FullName,
                StateId = _user.StateId,
                CityId = _user.CityId,
                CountryId = _user.CountryId,
                //Image = _user.Image,
                EmailId = _user.EmailId,
                Address = _user.Address,
                MobileNo = _user.MobileNo
            };
        }

    }
}