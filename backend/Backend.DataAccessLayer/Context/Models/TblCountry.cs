using System;
using System.Collections.Generic;

namespace Backend;

public partial class TblCountry
{
    public long CountryId { get; set; }

    public string? CountryName { get; set; }

    public virtual ICollection<TblUser> TblUsers { get; set; } = new List<TblUser>();
}
