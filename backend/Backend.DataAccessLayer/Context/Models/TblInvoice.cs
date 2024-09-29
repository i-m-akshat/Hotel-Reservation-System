using System;
using System.Collections.Generic;

namespace Backend.DataAccessLayer.Context.Models;

public partial class TblInvoice
{
    public int Id { get; set; }

    public long? UserId { get; set; }

    public long? ReservationId { get; set; }

    public decimal? Amount { get; set; }

    public DateTime? Issueddate { get; set; }

    public DateTime? Paiddate { get; set; }

    public DateTime? Cancelleddate { get; set; }

    public virtual TblReservation? Reservation { get; set; }

    public virtual TblUser? User { get; set; }
}
