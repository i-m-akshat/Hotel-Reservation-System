using System;
using System.Collections.Generic;

namespace Backend.DataAccessLayer.Context.Models;

public partial class TblChannelused
{
    public int Id { get; set; }

    public int? ChannelId { get; set; }

    public long? RoomId { get; set; }

    public virtual TblChannel? Channel { get; set; }

    public virtual TblRoom IdNavigation { get; set; } = null!;
}
