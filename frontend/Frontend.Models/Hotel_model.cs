using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.Models
{
    public class Hotel_model
    {
        public long HotelId { get; set; }

        public string HotelName { get; set; }

        public string HotelDescription { get; set; }

        public string Address { get; set; }

        public long CountryId { get; set; }
        public string CountryName { get; set; } 

        public long StateId { get; set; }
        public string StateName { get; set; }

        public long CityId { get; set; }
        public string CityName { get; set; }

        public bool IsActive { get; set; }

        public long CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public long UpdatedBy { get; set; }

        public DateTime UpdatedDate { get; set; }

        public long DeletedBy { get; set; }

        public DateTime DeletedDate { get; set; }

        public long CategoryId { get; set; }

        public byte[] IconImage { get; set; }

        public byte[] BannerImage { get; set; }

        public string Longitude { get; set; }

        public string Latitude { get; set; }
    }
}
