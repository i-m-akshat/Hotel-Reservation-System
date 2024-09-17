using System;
using System.Collections.Generic;

namespace Backend;

public partial class TblUser
{
    public long Id { get; set; }

    public string? UserId { get; set; }

    public string? FullName { get; set; }

    public string? Address { get; set; }

    public long? StateId { get; set; }

    public long? CityId { get; set; }

    public long? CountryId { get; set; }

    public byte[]? Image { get; set; }

    public string? EmailId { get; set; }

    public string? MobileNo { get; set; }

    public string? Password { get; set; }

    public string? Salt { get; set; }

    public string? Key { get; set; }

    public string? Iv { get; set; }

    public virtual TblCity? City { get; set; }

    public virtual TblCountry? Country { get; set; }

    public virtual TblState? State { get; set; }

    public virtual ICollection<TblInvoice> TblInvoices { get; set; } = new List<TblInvoice>();

    public virtual ICollection<TblReservation> TblReservations { get; set; } = new List<TblReservation>();

    public virtual TblReview? TblReview { get; set; }
}
