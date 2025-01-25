using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.Models
{
    public class HotelImage_model
    {
        public int HotelImageId { get; set; }

        public long HotelId { get; set; }
        public string HotelName { get; set; }

        public string ImageName { get; set; }

        public byte[] Image { get; set; }

        public string ContentType { get; set; }

        public bool Isactive { get; set; }

        public DateTime Createddate { get; set; }

        public long Createdby { get; set; }

        public DateTime Updateddate { get; set; }

        public long Updatedby { get; set; }

        public DateTime Deleteddate { get; set; }

        public long Deletedby { get; set; }
    }
    public class HotelImage_ModelWithoutDates
    {
        public int HotelImageId { get; set; }
        public string HotelName { get; set; }
        public long HotelId { get; set; } 

        public string ImageName { get; set; }

        public byte[] Image { get; set; }

        public string ContentType { get; set; }

        public bool Isactive { get; set; }
    }
}
