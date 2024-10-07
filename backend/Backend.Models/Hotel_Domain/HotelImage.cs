using Backend.Domain.Session_Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Models.Hotel_Domain
{
    public class HotelImage
    {
        public int HotelImageId { get; set; }

        public long? HotelId { get; set; }

        public string? ImageName { get; set; }

        public string? ImageUrl { get; set; }

        public string? ContentType { get; set; }

        public bool? Isactive { get; set; }

        public DateTime? Createddate { get; set; }

        public long? Createdby { get; set; }

        public DateTime? Updateddate { get; set; }

        public long? Updatedby { get; set; }

        public DateTime? Deleteddate { get; set; }

        public long? Deletedby { get; set; }

        public virtual AdminSession? CreatedbyNavigation { get; set; }

        public virtual AdminSession? DeletedbyNavigation { get; set; }

        public virtual Hotel? Hotel { get; set; }

        public virtual AdminSession? UpdatedbyNavigation { get; set; }
    }
}
