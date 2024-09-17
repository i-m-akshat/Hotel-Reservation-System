using System;
using System.Collections.Generic;

namespace Backend;

public partial class TblState
{
    public long StateId { get; set; }

    public string? StateName { get; set; }

    public long? CountryId { get; set; }

    public virtual ICollection<TblUser> TblUsers { get; set; } = new List<TblUser>();
}
