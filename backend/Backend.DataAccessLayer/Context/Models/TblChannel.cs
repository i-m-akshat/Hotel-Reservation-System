using System;
using System.Collections.Generic;

namespace Backend.DataAccessLayer.Context.Models;

public partial class TblChannel
{
    public int ChannelId { get; set; }

    public string? ChannelName { get; set; }

    public string? Details { get; set; }

    public DateTime? Createddate { get; set; }

    public long? Createdby { get; set; }

    public DateTime? Updateddate { get; set; }

    public long? Updatedby { get; set; }

    public DateTime? Deleteddate { get; set; }

    public long? Deletedby { get; set; }

    public virtual TblAdminSession? CreatedbyNavigation { get; set; }

    public virtual TblAdminSession? DeletedbyNavigation { get; set; }

    public virtual ICollection<TblChannelused> TblChanneluseds { get; set; } = new List<TblChannelused>();

    public virtual TblAdminSession? UpdatedbyNavigation { get; set; }
}
