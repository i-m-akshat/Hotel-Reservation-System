using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Models.Reservation_Domain
{
    public class ReservationEventStatus
    {
        public long Id { get; set; }

        public long? ReservationId { get; set; }

        public long? ReservatioinStatusId { get; set; }

        public string? Details { get; set; }

        public DateTime? CreatedDate { get; set; }
    }
}
