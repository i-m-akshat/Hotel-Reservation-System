using System;
using System.Collections.Generic;

namespace Backend.DataAccessLayer.Context.Models;

public partial class TblReservation
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

    public virtual TblAdminSession? CreatedbyNavigation { get; set; }

    public virtual TblAdminSession? DeletedByNavigation { get; set; }

    public virtual ICollection<TblInvoice> TblInvoices { get; set; } = new List<TblInvoice>();

    public virtual TblAdminSession? UpdatedbyNavigation { get; set; }

    public virtual TblUser? User { get; set; }
}