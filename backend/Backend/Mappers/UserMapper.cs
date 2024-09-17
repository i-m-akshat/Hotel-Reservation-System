
using Backend.Domain.User_Domain;
using Backend.DTO.User;

namespace Backend.Mappers
{
    public static class UserMapper
    {
        //mapping the user model to user data transfer object
        public static User_DTO ToUserDto_Common(this User _user)
        {
            return new User_DTO
            {
                UserId = _user.UserId,
                FullName = _user.FullName,
                StateName = _user.StateName,
                CityName = _user.CityName,
                CountryName = _user.CountryName,
                Image = _user.Image,
                EmailId = _user.EmailId,
                Address = _user.Address,
                MobileNo = _user.MobileNo,
            };

        }
        public static User_registerDto ToUserDto_Register(this User _user) {
            return new User_registerDto
            {
                FullName = _user.FullName,
                StateId = _user.StateId,
                CityId = _user.CityId,
                CountryId = _user.CountryId,
                //Image = _user.Image,
                EmailId = _user.EmailId,
                Address = _user.Address,
                MobileNo = _user.MobileNo,
                Password=_user.Password
            };

        }
        public static User_DTO ToUserDto_Login(this User _user) {
            User_DTO dto = new User_DTO
            {
                FullName = _user.FullName,
                StateName = _user.StateName,
                CityName = _user.CityName,
                CountryName = _user.CountryName,
                Image = _user.Image,
                EmailId = _user.EmailId,
                Address = _user.Address,
                MobileNo = _user.MobileNo,
                Password = _user.Password
            };
            return dto;
        }
        //mapping the user dto to user model
        public static User ToUserModelFromDTO(this User_DTO _DTO)
        {
            return new User
            {
                FullName = _DTO.FullName,
                StateName = _DTO.StateName,
                CountryName = _DTO.CountryName,
                CityName = _DTO.CityName,
                Address = _DTO.Address,
                MobileNo = _DTO.MobileNo,
                Password = _DTO.Password,

            };
        }
        public static User ToUserModelFromRegisterDTO(this User_registerDto _DTO)
        {
            return new User
            {
                UserId=_DTO.UserId,
                FullName = _DTO.FullName,
                StateId = _DTO.StateId,
                CountryId = _DTO.CountryId,
                CityId = _DTO.CityId,
                Address = _DTO.Address,
                MobileNo = _DTO.MobileNo,
                Password = _DTO.Password,
                EmailId=_DTO.EmailId,
                //Image=_DTO.Image,

            };
        }
    }
}
