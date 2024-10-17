using System;
using System.Collections.Generic;

namespace Backend.DataAccessLayer.Context.Models;

public partial class TblAdminSession
{
    public long SessionId { get; set; }

    public long? AdminId { get; set; }

    public DateTime? SessionStart { get; set; }

    public DateTime? SessionEnd { get; set; }

    public string? DeviceType { get; set; }

    public string? Devicelocation { get; set; }

    public string? IpAddress { get; set; }

    public virtual ICollection<TblAccess> TblAccesses { get; set; } = new List<TblAccess>();

    public virtual ICollection<TblAdmin> TblAdminCreatedbyNavigations { get; set; } = new List<TblAdmin>();

    public virtual ICollection<TblAdmin> TblAdminDeletedByNavigations { get; set; } = new List<TblAdmin>();

    public virtual ICollection<TblAdmin> TblAdminUpdatedByNavigations { get; set; } = new List<TblAdmin>();

    public virtual ICollection<TblChannel> TblChannelCreatedbyNavigations { get; set; } = new List<TblChannel>();

    public virtual ICollection<TblChannel> TblChannelDeletedbyNavigations { get; set; } = new List<TblChannel>();

    public virtual ICollection<TblChannel> TblChannelUpdatedbyNavigations { get; set; } = new List<TblChannel>();

    public virtual ICollection<TblHotel> TblHotelCreatedByNavigations { get; set; } = new List<TblHotel>();

    public virtual ICollection<TblHotel> TblHotelDeletedByNavigations { get; set; } = new List<TblHotel>();

    public virtual ICollection<TblHotel> TblHotelUpdatedByNavigations { get; set; } = new List<TblHotel>();

    public virtual ICollection<TblHotelcontactdetail> TblHotelcontactdetailCreatedbyNavigations { get; set; } = new List<TblHotelcontactdetail>();

    public virtual ICollection<TblHotelcontactdetail> TblHotelcontactdetailDeletedbyNavigations { get; set; } = new List<TblHotelcontactdetail>();

    public virtual ICollection<TblHotelcontactdetail> TblHotelcontactdetailUpdatedbyNavigations { get; set; } = new List<TblHotelcontactdetail>();

    public virtual ICollection<TblHotelimage> TblHotelimageCreatedbyNavigations { get; set; } = new List<TblHotelimage>();

    public virtual ICollection<TblHotelimage> TblHotelimageDeletedbyNavigations { get; set; } = new List<TblHotelimage>();

    public virtual ICollection<TblHotelimage> TblHotelimageUpdatedbyNavigations { get; set; } = new List<TblHotelimage>();

    public virtual ICollection<TblReservation> TblReservationCreatedbyNavigations { get; set; } = new List<TblReservation>();

    public virtual ICollection<TblReservation> TblReservationDeletedByNavigations { get; set; } = new List<TblReservation>();

    public virtual ICollection<TblReservationStatus> TblReservationStatusCreatedbyNavigations { get; set; } = new List<TblReservationStatus>();

    public virtual ICollection<TblReservationStatus> TblReservationStatusDeletedByNavigations { get; set; } = new List<TblReservationStatus>();

    public virtual ICollection<TblReservationStatus> TblReservationStatusUpdatedbyNavigations { get; set; } = new List<TblReservationStatus>();

    public virtual ICollection<TblReservation> TblReservationUpdatedbyNavigations { get; set; } = new List<TblReservation>();

    public virtual ICollection<TblRole> TblRoleCreatedbyNavigations { get; set; } = new List<TblRole>();

    public virtual ICollection<TblRole> TblRoleDeletedbyNavigations { get; set; } = new List<TblRole>();

    public virtual ICollection<TblRole> TblRoleUpdatedByNavigations { get; set; } = new List<TblRole>();

    public virtual ICollection<TblRoomtype> TblRoomtypeCreatedbyNavigations { get; set; } = new List<TblRoomtype>();

    public virtual ICollection<TblRoomtype> TblRoomtypeDeletedbyNavigations { get; set; } = new List<TblRoomtype>();

    public virtual ICollection<TblRoomtype> TblRoomtypeUpdatedbyNavigations { get; set; } = new List<TblRoomtype>();
}