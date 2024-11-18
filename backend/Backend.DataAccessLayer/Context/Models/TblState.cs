using System;
using System.Collections.Generic;

namespace Backend.DataAccessLayer.Context.Models;

public partial class TblState
{
    public long StateId { get; set; }

    public string? StateName { get; set; }

    public long? CountryId { get; set; }
    public bool? IsActive { get; set; }

    public virtual TblCountry? Country { get; set; }

    public virtual ICollection<TblCity> TblCities { get; set; } = new List<TblCity>();

    public virtual ICollection<TblUser> TblUsers { get; set; } = new List<TblUser>();
}