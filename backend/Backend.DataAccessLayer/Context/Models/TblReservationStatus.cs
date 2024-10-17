using System;
using System.Collections.Generic;

namespace Backend.DataAccessLayer.Context.Models;

public partial class TblReservationStatus
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

    public virtual TblAdminSession? CreatedbyNavigation { get; set; }

    public virtual TblAdminSession? DeletedByNavigation { get; set; }

    public virtual TblAdminSession? UpdatedbyNavigation { get; set; }
}