using Backend.Domain.Session_Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Models.Reservation_Domain
{
    public class ReservationStatus
    {
        public long ReservationStatusId { get; set; }

        public string? Status { get; set; }

        public DateTime? CreatedDate { get; set; }

        public long? Createdby { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public long? Updatedby { get; set; }

        public DateTime? DeletedDate { get; set; }

        public long? DeletedBy { get; set; }

        public bool? IsActive { get; set; }

        public virtual AdminSession? CreatedbyNavigation { get; set; }

        public virtual AdminSession? DeletedByNavigation { get; set; }

        public virtual AdminSession? UpdatedbyNavigation { get; set; }
    }
}
