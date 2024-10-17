using System;
using System.Collections.Generic;

namespace Backend.DataAccessLayer.Context.Models;

public partial class TblRoom
{
    public int RoomId { get; set; }

    public long? HotelId { get; set; }

    public long? RoomTypeId { get; set; }

    public string? Description { get; set; }

    public decimal? CurrentPrice { get; set; }

    public bool? IsReserved { get; set; }

    public bool? Isactive { get; set; }

    public DateTime? Createddate { get; set; }

    public long? Createdby { get; set; }

    public DateTime? Updateddate { get; set; }

    public long? Updatedby { get; set; }

    public DateTime? Deleteddate { get; set; }

    public long? Deletedby { get; set; }

    public string? Bannerimage { get; set; }

    public string? Iconimage { get; set; }

    public virtual TblChannelused? TblChannelused { get; set; }

    public virtual ICollection<TblReservedRoom> TblReservedRooms { get; set; } = new List<TblReservedRoom>();
}