using System;
using System.Collections.Generic;

namespace Backend.DataAccessLayer.Context.Models;

public partial class TblCity
{
    /// <summary>
    /// Id of the City
    /// </summary>
    public long CityId { get; set; }
    /// <summary>
    /// Name of the city
    /// </summary>
    public string? CityName { get; set; }
    /// <summary>
    /// id of the state associated with the city
    /// </summary>
    public long? StateId { get; set; }
    /// <summary>
    /// denotes whether the item is active or not 
    /// </summary>
    public bool? IsActive { get; set; }
    /// <summary>
    /// id of the country associated with the city
    /// </summary>
    public long? CountryId { get; set; }
    /// <summary>
    /// Navigation property- This represent the relationship between TblCity and TblState and also the virtual keyword allow for lazy loading 
    /// </summary>
    
   
    public virtual TblState? State { get; set; }
    /// <summary>
    /// Navigation property- This represent the relationship between TblCity and TblCountry and also the virtula keyword allows for lazy loading
    /// </summary>
    public virtual TblCountry? Country { get; set; }
    /// <summary>
    /// Navigation Property- One to many relationship between tblCity and TblUser This means that a city can have multiple Users associated with it.
    /// </summary>
    public virtual ICollection<TblUser> TblUsers { get; set; } = new List<TblUser>();
    public virtual ICollection<TblHotel> TblHotels { get; set; } = new List<TblHotel>();
}