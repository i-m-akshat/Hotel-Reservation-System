using System;
using System.Collections.Generic;

namespace Backend.DataAccessLayer.Context.Models;

public partial class TblReview
{
    public long ReviewId { get; set; }

    public long? HotelId { get; set; }

    public int? Rating { get; set; }

    public string? Comment { get; set; }

    public DateTime? ReviewedDate { get; set; }

    public long? ReviewedBy { get; set; }

    public virtual TblUser Review { get; set; } = null!;
}
