using System;
using System.Collections.Generic;

namespace Backend.DataAccessLayer.Context.Models;

public partial class TblRoomimage
{
    public int RoomImageId { get; set; }

    public int? RoomId { get; set; }

    public string? ImageName { get; set; }

    public string? ImageUrl { get; set; }

    public string? ContentType { get; set; }

    public bool? Isactive { get; set; }

    public DateTime? Createddate { get; set; }

    public long? Createdby { get; set; }

    public DateTime? Updateddate { get; set; }

    public long? Updatedby { get; set; }

    public DateTime? Deleteddate { get; set; }

    public long? Deletedby { get; set; }

    public virtual TblAdminSession? CreatedbyNavigation { get; set; }

    public virtual TblAdminSession? DeletedbyNavigation { get; set; }

    public virtual TblRoom? Room { get; set; }

    public virtual TblAdminSession? UpdatedbyNavigation { get; set; }
}