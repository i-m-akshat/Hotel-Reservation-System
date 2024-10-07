using Backend.Domain.Reservation_Domain;
using Backend.Models.Channel_Domain;
using Backend.Models.Hotel_Domain;
using Backend.Models.Reservation_Domain;
using Backend.Models.Room_Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Models.Admin_Domain
{
    public class AdminSession
    {
        public long SessionId { get; set; }

        public long? AdminId { get; set; }

        public DateTime? SessionStart { get; set; }

        public DateTime? SessionEnd { get; set; }

        public string? DeviceType { get; set; }

        public string? Devicelocation { get; set; }

        public string? IpAddress { get; set; }

        public virtual ICollection<Access> Accesses { get; set; } = new List<Access>();

        public virtual ICollection<Admin> AdminCreatedbyNavigations { get; set; } = new List<Admin>();

        public virtual ICollection<Admin> AdminDeletedByNavigations { get; set; } = new List<Admin>();

        public virtual ICollection<Admin> AdminUpdatedByNavigations { get; set; } = new List<Admin>();

        public virtual ICollection<Channel> ChannelCreatedbyNavigations { get; set; } = new List<Channel>();

        public virtual ICollection<Channel> ChannelDeletedbyNavigations { get; set; } = new List<Channel>();

        public virtual ICollection<Channel> ChannelUpdatedbyNavigations { get; set; } = new List<Channel>();

        public virtual ICollection<Hotel> HotelCreatedByNavigations { get; set; } = new List<Hotel>();

        public virtual ICollection<Hotel> HotelDeletedByNavigations { get; set; } = new List<Hotel>();

        public virtual ICollection<Hotel> HotelUpdatedByNavigations { get; set; } = new List<Hotel>();

        public virtual ICollection<HotelContactDetails> HotelcontactdetailCreatedbyNavigations { get; set; } = new List<HotelContactDetails>();

        public virtual ICollection<HotelContactDetails> HotelcontactdetailDeletedbyNavigations { get; set; } = new List<HotelContactDetails>();

        public virtual ICollection<HotelContactDetails> HotelcontactdetailUpdatedbyNavigations { get; set; } = new List<HotelContactDetails>();

        public virtual ICollection<HotelImage> HotelimageCreatedbyNavigations { get; set; } = new List<HotelImage>();

        public virtual ICollection<HotelImage> HotelimageDeletedbyNavigations { get; set; } = new List<HotelImage>();

        public virtual ICollection<HotelImage> HotelimageUpdatedbyNavigations { get; set; } = new List<HotelImage>();

        public virtual ICollection<Reservation> ReservationCreatedbyNavigations { get; set; } = new List<Reservation>();

        public virtual ICollection<Reservation> ReservationDeletedByNavigations { get; set; } = new List<Reservation>();

        public virtual ICollection<ReservationStatus> ReservationStatusCreatedbyNavigations { get; set; } = new List<ReservationStatus>();

        public virtual ICollection<ReservationStatus> ReservationStatusDeletedByNavigations { get; set; } = new List<ReservationStatus>();

        public virtual ICollection<ReservationStatus> ReservationStatusUpdatedbyNavigations { get; set; } = new List<ReservationStatus>();

        public virtual ICollection<Reservation> ReservationUpdatedbyNavigations { get; set; } = new List<Reservation>();

        public virtual ICollection<Role> RoleCreatedbyNavigations { get; set; } = new List<Role>();

        public virtual ICollection<Role> RoleDeletedbyNavigations { get; set; } = new List<Role>();

        public virtual ICollection<Role> RoleUpdatedByNavigations { get; set; } = new List<Role>();

        public virtual ICollection<RoomType> RoomtypeCreatedbyNavigations { get; set; } = new List<RoomType>();

        public virtual ICollection<RoomType> RoomtypeDeletedbyNavigations { get; set; } = new List<RoomType>();

        public virtual ICollection<RoomType> RoomtypeUpdatedbyNavigations { get; set; } = new List<RoomType>();
    }
}
