using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Domain.Reservation_Domain;
using Backend.Domain.User_Domain;

namespace Backend.Domain.Invoice_Domain
{
    public  class Invoice
    {
        public int Id { get; set; }

        public long? UserId { get; set; }

        public long? ReservationId { get; set; }

        public decimal? Amount { get; set; }

        public DateTime? Issueddate { get; set; }

        public DateTime? Paiddate { get; set; }

        public DateTime? Cancelleddate { get; set; }

        public virtual Reservation? Reservation { get; set; }

        public virtual User? User { get; set; }
    }
}
