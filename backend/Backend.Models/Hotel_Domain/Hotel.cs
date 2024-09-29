using Backend.Domain.Session_Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Models.Hotel_Domain
{
    public class Hotel
    {
        public long HotelId { get; set; }

        public string? HotelName { get; set; }

        public string? HotelDescription { get; set; }

        public string? Address { get; set; }

        public long CountryId { get; set; }

        public long? StateId { get; set; }

        public long? CityId { get; set; }

        public bool? IsActive { get; set; }

        public long? CreatedBy { get; set; }

        public DateTime? CreatedDate { get; set; }

        public long? UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public long? DeletedBy { get; set; }

        public DateTime? DeletedDate { get; set; }

        public long? CategoryId { get; set; }

        public byte[]? IconImage { get; set; }

        public byte[]? BannerImage { get; set; }

        public string? Longitude { get; set; }

        public string? Latitude { get; set; }

        public virtual AdminSession? CreatedByNavigation { get; set; }

        public virtual AdminSession? DeletedByNavigation { get; set; }

        public virtual ICollection<HotelContactDetails> Hotelcontactdetails { get; set; } = new List<HotelContactDetails>();

        public virtual ICollection<HotelImage> Hotelimages { get; set; } = new List<HotelImage>();

        public virtual AdminSession? UpdatedByNavigation { get; set; }
    }
}
