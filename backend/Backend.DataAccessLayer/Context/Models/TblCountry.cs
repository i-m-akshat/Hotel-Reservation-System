using System;
using System.Collections.Generic;

namespace Backend.DataAccessLayer.Context.Models;

public partial class TblCountry
{
    public long CountryId { get; set; }

    public string? CountryName { get; set; }
    public bool? isActive { get; set; }  

    public virtual ICollection<TblState> TblStates { get; set; } = new List<TblState>();
    public virtual ICollection<TblCity> TblCities { get; set; }=new List<TblCity>();
    public virtual ICollection<TblUser> TblUsers { get; set; } = new List<TblUser>();
    public virtual ICollection<TblHotel> TblHotels { get;set; }=new List<TblHotel>();
}