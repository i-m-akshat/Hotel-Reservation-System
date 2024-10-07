using System;
using System.Collections.Generic;

namespace Backend.DataAccessLayer.Context.Models;

public partial class TblCity
{
    public long CityId { get; set; }

    public string? CityName { get; set; }

    public long? StateId { get; set; }

    public virtual TblState? State { get; set; }

    public virtual ICollection<TblUser> TblUsers { get; set; } = new List<TblUser>();
}
