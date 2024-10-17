using System;
using System.Collections.Generic;

namespace Backend.DataAccessLayer.Context.Models;

public partial class TblCountry
{
    public long CountryId { get; set; }

    public string? CountryName { get; set; }

    public virtual ICollection<TblState> TblStates { get; set; } = new List<TblState>();

    public virtual ICollection<TblUser> TblUsers { get; set; } = new List<TblUser>();
}