using System;
using System.Collections.Generic;

namespace Backend.DataAccessLayer.Context.Models;

public partial class TblHotel
{
    public long HotelId { get; set; }

    public string? HotelName { get; set; }

    public string? HotelDescription { get; set; }

    public string? Address { get; set; }

    public long CountryId { get; set; }

    public long? StateId { get; set; }

    public long? CityId { get; set; }

    public bool? IsActive { get; set; }

    public long? CreatedBy { get; set; }

    public DateTime? CreatedDate { get; set; }

    public long? UpdatedBy { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public long? DeletedBy { get; set; }

    public DateTime? DeletedDate { get; set; }

    public long? CategoryId { get; set; }

    public byte[]? IconImage { get; set; }

    public byte[]? BannerImage { get; set; }

    public string? Longitude { get; set; }

    public string? Latitude { get; set; }

    public virtual TblCity? City { get; set; }

    public virtual TblCountry? Country { get; set; }

    public virtual TblState? State { get; set; }
    public virtual TblAdminSession? CreatedByNavigation { get; set; }

    public virtual TblAdminSession? DeletedByNavigation { get; set; }

    public virtual ICollection<TblHotelcontactdetail> TblHotelcontactdetails { get; set; } = new List<TblHotelcontactdetail>();

    public virtual ICollection<TblHotelimage> TblHotelimages { get; set; } = new List<TblHotelimage>();

    public virtual TblAdminSession? UpdatedByNavigation { get; set; }
}