using Backend.Domain.Session_Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Models.Room_Domain
{
    public class Room
    {
        public int RoomTypeId { get; set; }

        public string? RoomType { get; set; }

        public bool? Isactive { get; set; }

        public DateTime? Createddate { get; set; }

        public long? Createdby { get; set; }

        public DateTime? Updateddate { get; set; }

        public long? Updatedby { get; set; }

        public DateTime? Deleteddate { get; set; }

        public long? Deletedby { get; set; }

        public virtual AdminSession? CreatedbyNavigation { get; set; }

        public virtual AdminSession? DeletedbyNavigation { get; set; }

        public virtual AdminSession? UpdatedbyNavigation { get; set; }
    }
}
