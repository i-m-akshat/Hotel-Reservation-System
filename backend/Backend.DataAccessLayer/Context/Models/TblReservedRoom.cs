using System;
using System.Collections.Generic;

namespace Backend;

public partial class TblReservedRoom
{
    public long Id { get; set; }

    public long? ReservationId { get; set; }

    public int? RoomId { get; set; }

    public decimal? Price { get; set; }

    public virtual TblRoom? Room { get; set; }
}
