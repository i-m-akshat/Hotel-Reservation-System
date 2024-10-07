using System;
using System.Collections.Generic;

namespace Backend.DataAccessLayer.Context.Models;

public partial class TblReservationEventStatus
{
    public long Id { get; set; }

    public long? ReservationId { get; set; }

    public long? ReservatioinStatusId { get; set; }

    public string? Details { get; set; }

    public DateTime? CreatedDate { get; set; }
}
