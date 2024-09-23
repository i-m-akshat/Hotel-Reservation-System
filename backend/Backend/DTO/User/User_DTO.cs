namespace Backend.DTO.User
{
    public class User_DTO
    {
       

        public string? UserId { get; set; }

        public string? FullName { get; set; }

        public string? Address { get; set; }

        //public long? StateId { get; set; }

        public string StateName { get; set; }   =string.Empty;

        //public long? CityId { get; set; }
        public string CityName { get; set; } = string.Empty;

        //public long? CountryId { get; set; }
        public string CountryName { get; set; } = string.Empty;

        public byte[]? Image { get; set; }

        public string? EmailId { get; set; }

        public string? MobileNo { get; set; }
      
        public string Password { get; set; }
    }
    public class User_registerDto()
    {
        public string? UserId { get; set; }

        public string? FullName { get; set; }

        public string? Address { get; set; }

        public long? StateId { get; set; }

        //public string StateName { get; set; } = string.Empty;

        public long? CityId { get; set; }
        //public string CityName { get; set; } = string.Empty;

        public long? CountryId { get; set; }
        //public string CountryName { get; set; } = string.Empty;

        //public byte[]? Image { get; set; }

        public string? EmailId { get; set; }

        public string? MobileNo { get; set; }

        public string Password { get; set; }
    }
    public class User_loginDto
    {
        public string UserID { get; set; }
        public string Password { get; set; }
    }
    public class User_loginDTODetails
    {
        public string? FullName { get; set; }

        public string? Address { get; set; }

        public long? StateId { get; set; }

        //public string StateName { get; set; } = string.Empty;

        public long? CityId { get; set; }
        //public string CityName { get; set; } = string.Empty;

        public long? CountryId { get; set; }
        //public string CountryName { get; set; } = string.Empty;

        //public byte[]? Image { get; set; }

        public string? EmailId { get; set; }

        public string? MobileNo { get; set; }
    }
}
