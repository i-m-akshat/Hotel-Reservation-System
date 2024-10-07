using Backend.DataAccessLayer.Context.Models;
using Backend.Domain.User_Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Services.Mapper
{
    public static class TblUserToUserMapper
    {
        public static User ToUser(this TblUser _user)
        {
            try
            {
                return new User
                {
                    UserId=_user.UserId,
                    FullName = _user.FullName,
                    StateName = _user.State!=null? _user.State.StateName:"",
                    CountryName = _user.Country!=null?_user.Country.CountryName:"",
                    CityName = _user.City!=null?_user.City.CityName:"",
                    Address = _user.Address,
                    MobileNo = _user.MobileNo,
                    Password = _user.Password,
                    EmailId=_user.EmailId,
                };
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        public static TblUser ToTblUser(this User _user)
        {
            try
            {
                return new TblUser
                {
                    FullName = _user.FullName,
                    //StateName = _user.State != null ? _user.State.StateName : "",
                    //CountryName = _user.Country != null ? _user.Country.CountryName : "",
                    //CityName = _user.City != null ? _user.City.CityName : "",
                    StateId=_user.StateId,
                    CountryId=_user.CountryId,
                    CityId=_user.CityId,
                    Address = _user.Address,
                    MobileNo = _user.MobileNo,
                    Password = _user.Password,
                    EmailId=_user.EmailId,
                    UserId=_user.UserId,    
                    //Image=_user.Image,
                };
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
