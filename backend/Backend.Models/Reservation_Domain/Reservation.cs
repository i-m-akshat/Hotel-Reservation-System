using Backend.Domain.Invoice_Domain;
using Backend.Domain.Session_Domain;
using Backend.Domain.User_Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Domain.Reservation_Domain
{
    public class Reservation
    {
        public long ReservationId { get; set; }

        public long? UserId { get; set; }

        public DateTime? CheckInDate { get; set; }

        public DateTime? CheckOutDate { get; set; }

        public decimal? TotalPrice { get; set; }

        public DateTime? Createddate { get; set; }

        public long? Createdby { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public long? Updatedby { get; set; }

        public DateTime? DeletedDate { get; set; }

        public long? DeletedBy { get; set; }

        public virtual AdminSession? CreatedbyNavigation { get; set; }

        public virtual AdminSession? DeletedByNavigation { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

        public virtual AdminSession? UpdatedbyNavigation { get; set; }

        public virtual User? User { get; set; }
    }
}
