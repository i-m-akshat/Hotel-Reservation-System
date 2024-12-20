using System;
using System.Collections.Generic;
using Backend.DataAccessLayer.Context.Models;
using Microsoft.EntityFrameworkCore;

namespace Backend.DataAccessLayer.Context.DBContext;

public partial class BaseraHotelReservationSystemContext : DbContext
{
    public BaseraHotelReservationSystemContext()
    {
    }

    public BaseraHotelReservationSystemContext(DbContextOptions<BaseraHotelReservationSystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblAccess> TblAccesses { get; set; }

    public virtual DbSet<TblAdmin> TblAdmins { get; set; }

    public virtual DbSet<TblAdminSession> TblAdminSessions { get; set; }

    public virtual DbSet<TblChannel> TblChannels { get; set; }

    public virtual DbSet<TblChannelused> TblChanneluseds { get; set; }

    public virtual DbSet<TblCity> TblCities { get; set; }

    public virtual DbSet<TblCountry> TblCountries { get; set; }

    public virtual DbSet<TblHotel> TblHotels { get; set; }

    public virtual DbSet<TblHotelcontactdetail> TblHotelcontactdetails { get; set; }

    public virtual DbSet<TblHotelimage> TblHotelimages { get; set; }

    public virtual DbSet<TblInvoice> TblInvoices { get; set; }

    public virtual DbSet<TblReservation> TblReservations { get; set; }

    public virtual DbSet<TblReservationEventStatus> TblReservationEventStatuses { get; set; }

    public virtual DbSet<TblReservationStatus> TblReservationStatuses { get; set; }

    public virtual DbSet<TblReservedRoom> TblReservedRooms { get; set; }

    public virtual DbSet<TblReview> TblReviews { get; set; }

    public virtual DbSet<TblRole> TblRoles { get; set; }

    public virtual DbSet<TblRoom> TblRooms { get; set; }

    public virtual DbSet<TblRoomimage> TblRoomimages { get; set; }

    public virtual DbSet<TblRoomtype> TblRoomtypes { get; set; }

    public virtual DbSet<TblState> TblStates { get; set; }

    public virtual DbSet<TblUser> TblUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-RBREH2D\\SQLEXPRESS;Database=Basera_HotelReservationSystem;Trusted_Connection=True;Trust Server Certificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblAccess>(entity =>
        {
            entity.ToTable("tbl_Access");

            entity.Property(e => e.Id)
                .HasColumnName("ID");
            entity.Property(e => e.AccessProvidedDate).HasColumnType("datetime");
            entity.Property(e => e.AccessUrl)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("AccessURL");
            entity.Property(e => e.IconUrl)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.RoleId).HasColumnName("RoleID");

            entity.HasOne(d => d.AccessProvidedByNavigation).WithMany(p => p.TblAccesses)
                .HasForeignKey(d => d.AccessProvidedBy)
                .HasConstraintName("FK_tbl_Access_tbl_Admin");

            entity.HasOne(d => d.Role).WithMany(p => p.TblAccesses)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK_tbl_Access_tbl_Role");
        });

        modelBuilder.Entity<TblAdmin>(entity =>
        {
            entity.HasKey(e => e.AdminId);

            entity.ToTable("tbl_Admin");

            entity.Property(e => e.AdminId).HasColumnName("AdminID");
            entity.Property(e => e.RoleID).HasColumnName("RoleID");
            entity.Property(e => e.Address).HasMaxLength(500);
            entity.Property(e => e.Adminname)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.CityId).HasColumnName("CityID");
            entity.Property(e => e.CountryId).HasColumnName("CountryID");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DeletedDate).HasColumnType("datetime");
            entity.Property(e => e.EmailId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("EmailID");
            entity.Property(e => e.FullName)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.StateId).HasColumnName("StateID");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.CreatedbyNavigation).WithMany(p => p.TblAdminCreatedbyNavigations)
                .HasForeignKey(d => d.Createdby)
                .HasConstraintName("FK_tbl_Admin_tbl_AdminSession");

            entity.HasOne(d => d.DeletedByNavigation).WithMany(p => p.TblAdminDeletedByNavigations)
                .HasForeignKey(d => d.DeletedBy)
                .HasConstraintName("FK_tbl_Admin_tbl_AdminSession1");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.TblAdminUpdatedByNavigations)
                .HasForeignKey(d => d.UpdatedBy)
                .HasConstraintName("FK_tbl_Admin_tbl_AdminSession2");
        });

        modelBuilder.Entity<TblAdminSession>(entity =>
        {
            entity.HasKey(e => e.SessionId);

            entity.ToTable("tbl_AdminSession");

            entity.Property(e => e.SessionId).HasColumnName("session_id");
            entity.Property(e => e.AdminId).HasColumnName("Admin_id");
            entity.Property(e => e.DeviceType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Devicelocation)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.IpAddress)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("IP_Address");
            entity.Property(e => e.SessionEnd)
                .HasColumnType("datetime")
                .HasColumnName("Session_end");
            entity.Property(e => e.SessionStart)
                .HasColumnType("datetime")
                .HasColumnName("Session_start");
        });

        modelBuilder.Entity<TblChannel>(entity =>
        {
            entity.HasKey(e => e.ChannelId);

            entity.ToTable("tbl_channel");

            entity.Property(e => e.ChannelId).HasColumnName("channel_id");
            entity.Property(e => e.ChannelName)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("channel_name");
            entity.Property(e => e.Createdby).HasColumnName("createdby");
            entity.Property(e => e.Createddate)
                .HasPrecision(3)
                .HasColumnName("createddate");
            entity.Property(e => e.Deletedby).HasColumnName("deletedby");
            entity.Property(e => e.Deleteddate)
                .HasPrecision(3)
                .HasColumnName("deleteddate");
            entity.Property(e => e.Details)
                .IsUnicode(false)
                .HasColumnName("details");
            entity.Property(e => e.Updatedby).HasColumnName("updatedby");
            entity.Property(e => e.Updateddate)
                .HasPrecision(3)
                .HasColumnName("updateddate");

            entity.HasOne(d => d.CreatedbyNavigation).WithMany(p => p.TblChannelCreatedbyNavigations)
                .HasForeignKey(d => d.Createdby)
                .HasConstraintName("FK_tbl_channel_tbl_AdminSession");

            entity.HasOne(d => d.DeletedbyNavigation).WithMany(p => p.TblChannelDeletedbyNavigations)
                .HasForeignKey(d => d.Deletedby)
                .HasConstraintName("FK_tbl_channel_tbl_AdminSession1");

            entity.HasOne(d => d.UpdatedbyNavigation).WithMany(p => p.TblChannelUpdatedbyNavigations)
                .HasForeignKey(d => d.Updatedby)
                .HasConstraintName("FK_tbl_channel_tbl_AdminSession2");
        });

        modelBuilder.Entity<TblChannelused>(entity =>
        {
            entity.ToTable("tbl_channelused");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.ChannelId).HasColumnName("channel_id");
            entity.Property(e => e.RoomId).HasColumnName("room_id");

            entity.HasOne(d => d.Channel).WithMany(p => p.TblChanneluseds)
                .HasForeignKey(d => d.ChannelId)
                .HasConstraintName("FK_tbl_channelused_tbl_channel");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.TblChannelused)
                .HasForeignKey<TblChannelused>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tbl_channelused_tbl_room");
        });

        modelBuilder.Entity<TblCity>(entity =>
        {
            entity.HasKey(e => e.CityId);

            entity.ToTable("tbl_city");
            // Enable identity insert on Cityid
            entity.Property(e => e.CityId)
                .ValueGeneratedOnAdd()  // Enable auto-generation for CityId
                .HasColumnName("CityId");
            //entity.Property(e => e.CityId).ValueGeneratedNever();
            entity.Property(e => e.CityName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.StateId).HasColumnName("StateID");
            entity.Property(e => e.IsActive).HasColumnName("IsActive");
            entity.Property(e => e.CountryId).HasColumnName("CountryID");
            entity.HasOne(d => d.Country).WithMany(p => p.TblCities).HasForeignKey(d => d.CountryId).HasConstraintName("Fk_tbl_city_tbl_country");
            entity.HasOne(d => d.State).WithMany(p => p.TblCities)
                .HasForeignKey(d => d.StateId)
                .HasConstraintName("FK_tbl_city_tbl_State");
        });

        modelBuilder.Entity<TblCountry>(entity =>
        {
            entity.HasKey(e => e.CountryId);

            entity.ToTable("tbl_Country");

            entity.Property(e => e.CountryId).HasColumnName("countryId");
            entity.Property(e => e.isActive).HasColumnName("IsActive");
            entity.Property(e => e.CountryId)
        .ValueGeneratedOnAdd()  // Enable auto-generation for CountryId
        .HasColumnName("CountryId");
            entity.Property(e => e.CountryName)
                .HasMaxLength(500)
                .IsUnicode(false);
        });
        
        modelBuilder.Entity<TblHotel>(entity =>
        {
            entity.HasKey(e => e.HotelId);

            entity.ToTable("tbl_Hotel");

            entity.Property(e => e.HotelId).HasColumnName("HotelID");
            entity.Property(e => e.Address)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.BannerImage).HasColumnName("Banner_Image");
            //entity.Property(e => e.CategoryId).HasColumnName("Category_Id");
            entity.Property(e => e.CityId).HasColumnName("CityID");
            entity.Property(e => e.CountryId).HasColumnName("CountryId");
            entity.Property(e => e.StateId).HasColumnName("StateId");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DeletedDate).HasColumnType("datetime");
            entity.Property(e => e.HotelDescription).HasColumnName("Hotel_Description");
            entity.Property(e => e.HotelName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.IconImage).HasColumnName("Icon_Image");
            entity.Property(e => e.Latitude)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("latitude");
            entity.Property(e => e.Longitude)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("longitude");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.TblHotelCreatedByNavigations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK_tbl_Hotel_tbl_AdminSession");

            entity.HasOne(d => d.DeletedByNavigation).WithMany(p => p.TblHotelDeletedByNavigations)
                .HasForeignKey(d => d.DeletedBy)
                .HasConstraintName("FK_tbl_Hotel_tbl_AdminSession2");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.TblHotelUpdatedByNavigations)
                .HasForeignKey(d => d.UpdatedBy)
                .HasConstraintName("FK_tbl_Hotel_tbl_AdminSession1");
            entity.HasOne(d => d.Country).WithMany(p => p.TblHotels).HasForeignKey(d => d.CountryId).HasConstraintName("FK_tbl_Hotel_tbl_Country");
            entity.HasOne(d => d.State).WithMany(p => p.TblHotels).HasForeignKey(d => d.StateId).HasConstraintName("FK_tbl_Hotel_tbl_State");
            entity.HasOne(d => d.City).WithMany(p => p.TblHotels).HasForeignKey(d => d.CityId).HasConstraintName("FK_tbl_Hotel_tbl_City");
        });

        modelBuilder.Entity<TblHotelcontactdetail>(entity =>
        {
            entity.HasKey(e => e.ContactId).HasName("PK__tbl_hote__024E7A8656FE4844");

            entity.ToTable("tbl_hotelcontactdetails");

            entity.Property(e => e.ContactId).HasColumnName("contact_id");
            entity.Property(e => e.Createdby).HasColumnName("createdby");
            entity.Property(e => e.Createddate)
                .HasPrecision(3)
                .HasColumnName("createddate");
            entity.Property(e => e.Deletedby).HasColumnName("deletedby");
            entity.Property(e => e.Deleteddate)
                .HasPrecision(3)
                .HasColumnName("deleteddate");
            entity.Property(e => e.HotelContactType)
                .HasMaxLength(100)
                .HasColumnName("hotel_contact_type");
            entity.Property(e => e.HotelContactValue)
                .HasMaxLength(250)
                .HasColumnName("hotel_contact_value");
            entity.Property(e => e.HotelId).HasColumnName("hotel_id");
            entity.Property(e => e.Isactive).HasColumnName("isactive");
            entity.Property(e => e.Isprimary).HasColumnName("isprimary");
            entity.Property(e => e.Updatedby).HasColumnName("updatedby");
            entity.Property(e => e.Updateddate)
                .HasPrecision(3)
                .HasColumnName("updateddate");

            entity.HasOne(d => d.CreatedbyNavigation).WithMany(p => p.TblHotelcontactdetailCreatedbyNavigations)
                .HasForeignKey(d => d.Createdby)
                .HasConstraintName("FK_tbl_hotelcontactdetails_tbl_AdminSession1");

            entity.HasOne(d => d.DeletedbyNavigation).WithMany(p => p.TblHotelcontactdetailDeletedbyNavigations)
                .HasForeignKey(d => d.Deletedby)
                .HasConstraintName("FK_tbl_hotelcontactdetails_tbl_AdminSession");

            entity.HasOne(d => d.Hotel).WithMany(p => p.TblHotelcontactdetails)
                .HasForeignKey(d => d.HotelId)
                .HasConstraintName("FK_tbl_hotelcontactdetails_tbl_Hotel");

            entity.HasOne(d => d.UpdatedbyNavigation).WithMany(p => p.TblHotelcontactdetailUpdatedbyNavigations)
                .HasForeignKey(d => d.Updatedby)
                .HasConstraintName("FK_tbl_hotelcontactdetails_tbl_AdminSession2");
        });

        modelBuilder.Entity<TblHotelimage>(entity =>
        {
            entity.HasKey(e => e.HotelImageId).HasName("PK__tbl_hote__066CE50E30442154");

            entity.ToTable("tbl_hotelimage");

            entity.Property(e => e.HotelImageId).HasColumnName("hotel_image_id");
            entity.Property(e => e.ContentType)
                .HasMaxLength(10)
                .HasColumnName("content_type");
            entity.Property(e => e.Createdby).HasColumnName("createdby");
            entity.Property(e => e.Createddate)
                .HasPrecision(3)
                .HasColumnName("createddate");
            entity.Property(e => e.Deletedby).HasColumnName("deletedby");
            entity.Property(e => e.Deleteddate)
                .HasPrecision(3)
                .HasColumnName("deleteddate");
            entity.Property(e => e.HotelId).HasColumnName("hotel_id");
            entity.Property(e => e.ImageName)
                .HasMaxLength(200)
                .HasColumnName("image_name");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(600)
                .HasColumnName("image_url");
            entity.Property(e => e.Isactive).HasColumnName("isactive");
            entity.Property(e => e.Updatedby).HasColumnName("updatedby");
            entity.Property(e => e.Updateddate)
                .HasPrecision(3)
                .HasColumnName("updateddate");

            entity.HasOne(d => d.CreatedbyNavigation).WithMany(p => p.TblHotelimageCreatedbyNavigations)
                .HasForeignKey(d => d.Createdby)
                .HasConstraintName("FK_tbl_hotelimage_tbl_AdminSession");

            entity.HasOne(d => d.DeletedbyNavigation).WithMany(p => p.TblHotelimageDeletedbyNavigations)
                .HasForeignKey(d => d.Deletedby)
                .HasConstraintName("FK_tbl_hotelimage_tbl_AdminSession2");

            entity.HasOne(d => d.Hotel).WithMany(p => p.TblHotelimages)
                .HasForeignKey(d => d.HotelId)
                .HasConstraintName("FK_tbl_hotelimage_tbl_Hotel");

            entity.HasOne(d => d.UpdatedbyNavigation).WithMany(p => p.TblHotelimageUpdatedbyNavigations)
                .HasForeignKey(d => d.Updatedby)
                .HasConstraintName("FK_tbl_hotelimage_tbl_AdminSession1");
        });

        modelBuilder.Entity<TblInvoice>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tbl_invo__3213E83F1BD14D80");

            entity.ToTable("tbl_invoice");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Amount)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("amount");
            entity.Property(e => e.Cancelleddate)
                .HasPrecision(3)
                .HasColumnName("cancelleddate");
            entity.Property(e => e.Issueddate)
                .HasPrecision(3)
                .HasColumnName("issueddate");
            entity.Property(e => e.Paiddate)
                .HasPrecision(3)
                .HasColumnName("paiddate");
            entity.Property(e => e.ReservationId).HasColumnName("reservation_id");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.Reservation).WithMany(p => p.TblInvoices)
                .HasForeignKey(d => d.ReservationId)
                .HasConstraintName("FK_tbl_invoice_tbl_reservation");

            entity.HasOne(d => d.User).WithMany(p => p.TblInvoices)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_tbl_invoice_tbl_User");
        });

        modelBuilder.Entity<TblReservation>(entity =>
        {
            entity.HasKey(e => e.ReservationId);

            entity.ToTable("tbl_reservation");

            entity.Property(e => e.ReservationId).HasColumnName("reservation_id");
            entity.Property(e => e.CheckInDate)
                .HasColumnType("datetime")
                .HasColumnName("check_in_date");
            entity.Property(e => e.CheckOutDate)
                .HasColumnType("datetime")
                .HasColumnName("check_Out_date");
            entity.Property(e => e.Createdby).HasColumnName("createdby");
            entity.Property(e => e.Createddate)
                .HasColumnType("datetime")
                .HasColumnName("createddate");
            entity.Property(e => e.DeletedDate).HasColumnType("datetime");
            entity.Property(e => e.TotalPrice)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("total_price");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.UserId).HasColumnName("user_id");

            entity.HasOne(d => d.CreatedbyNavigation).WithMany(p => p.TblReservationCreatedbyNavigations)
                .HasForeignKey(d => d.Createdby)
                .HasConstraintName("FK_tbl_reservation_tbl_AdminSession1");

            entity.HasOne(d => d.DeletedByNavigation).WithMany(p => p.TblReservationDeletedByNavigations)
                .HasForeignKey(d => d.DeletedBy)
                .HasConstraintName("FK_tbl_reservation_tbl_AdminSession2");

            entity.HasOne(d => d.UpdatedbyNavigation).WithMany(p => p.TblReservationUpdatedbyNavigations)
                .HasForeignKey(d => d.Updatedby)
                .HasConstraintName("FK_tbl_reservation_tbl_AdminSession");

            entity.HasOne(d => d.User).WithMany(p => p.TblReservations)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_tbl_reservation_tbl_User");
        });

        modelBuilder.Entity<TblReservationEventStatus>(entity =>
        {
            entity.ToTable("tbl_reservation_event_status");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("createdDate");
            entity.Property(e => e.Details)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("details");
            entity.Property(e => e.ReservatioinStatusId).HasColumnName("reservatioin_Status_id");
            entity.Property(e => e.ReservationId).HasColumnName("reservation_id");
        });

        modelBuilder.Entity<TblReservationStatus>(entity =>
        {
            entity.HasKey(e => e.ReservationStatusId);

            entity.ToTable("tbl_reservation_status");

            entity.Property(e => e.ReservationStatusId).HasColumnName("reservation_status_id");
            entity.Property(e => e.CreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("createdDate");
            entity.Property(e => e.Createdby).HasColumnName("createdby");
            entity.Property(e => e.DeletedDate).HasColumnType("datetime");
            entity.Property(e => e.IsActive).HasColumnName("isActive");
            entity.Property(e => e.Status)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("status");
            entity.Property(e => e.UpdatedDate)
                .HasColumnType("datetime")
                .HasColumnName("updatedDate");

            entity.HasOne(d => d.CreatedbyNavigation).WithMany(p => p.TblReservationStatusCreatedbyNavigations)
                .HasForeignKey(d => d.Createdby)
                .HasConstraintName("FK_tbl_reservation_status_tbl_AdminSession2");

            entity.HasOne(d => d.DeletedByNavigation).WithMany(p => p.TblReservationStatusDeletedByNavigations)
                .HasForeignKey(d => d.DeletedBy)
                .HasConstraintName("FK_tbl_reservation_status_tbl_AdminSession1");

            entity.HasOne(d => d.UpdatedbyNavigation).WithMany(p => p.TblReservationStatusUpdatedbyNavigations)
                .HasForeignKey(d => d.Updatedby)
                .HasConstraintName("FK_tbl_reservation_status_tbl_AdminSession");
        });

        modelBuilder.Entity<TblReservedRoom>(entity =>
        {
            entity.ToTable("tbl_ReservedRooms");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("price");
            entity.Property(e => e.ReservationId).HasColumnName("reservation_id");
            entity.Property(e => e.RoomId).HasColumnName("room_id");

            entity.HasOne(d => d.Room).WithMany(p => p.TblReservedRooms)
                .HasForeignKey(d => d.RoomId)
                .HasConstraintName("FK_tbl_ReservedRooms_tbl_ReservedRooms");
        });

        modelBuilder.Entity<TblReview>(entity =>
        {
            entity.HasKey(e => e.ReviewId);

            entity.ToTable("tbl_review");

            entity.Property(e => e.ReviewId)
                .ValueGeneratedOnAdd()
                .HasColumnName("review_id");
            entity.Property(e => e.Comment).HasColumnName("comment");
            entity.Property(e => e.HotelId).HasColumnName("hotel_id");
            entity.Property(e => e.Rating).HasColumnName("rating");
            entity.Property(e => e.ReviewedBy).HasColumnName("reviewedBy");
            entity.Property(e => e.ReviewedDate)
                .HasColumnType("datetime")
                .HasColumnName("reviewedDate");

            entity.HasOne(d => d.Review).WithOne(p => p.TblReview)
                .HasForeignKey<TblReview>(d => d.ReviewId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tbl_review_tbl_User");
        });

        modelBuilder.Entity<TblRole>(entity =>
        {
            entity.HasKey(e => e.RoleId);

            entity.ToTable("tbl_Role");
            entity.Property(e => e.IsActive).HasColumnName("IsActive");
            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.DeletedDate).HasColumnType("datetime");
            entity.Property(e => e.Role)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.CreatedbyNavigation).WithMany(p => p.TblRoleCreatedbyNavigations)
                .HasForeignKey(d => d.Createdby)
                .HasConstraintName("FK_tbl_Role_tbl_AdminSession");

            entity.HasOne(d => d.DeletedbyNavigation).WithMany(p => p.TblRoleDeletedbyNavigations)
                .HasForeignKey(d => d.Deletedby)
                .HasConstraintName("FK_tbl_Role_tbl_AdminSession1");

            entity.HasOne(d => d.UpdatedByNavigation).WithMany(p => p.TblRoleUpdatedByNavigations)
                .HasForeignKey(d => d.UpdatedBy)
                .HasConstraintName("FK_tbl_Role_tbl_AdminSession2");
        });

        modelBuilder.Entity<TblRoom>(entity =>
        {
            entity.HasKey(e => e.RoomId).HasName("PK__tbl_room__19675A8A22DD1E4B");

            entity.ToTable("tbl_room");

            entity.Property(e => e.RoomId).HasColumnName("room_id");
            entity.Property(e => e.Bannerimage)
                .HasMaxLength(600)
                .HasColumnName("bannerimage");
            entity.Property(e => e.Createdby).HasColumnName("createdby");
            entity.Property(e => e.Createddate)
                .HasPrecision(3)
                .HasColumnName("createddate");
            entity.Property(e => e.CurrentPrice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("current_price");
            entity.Property(e => e.Deletedby).HasColumnName("deletedby");
            entity.Property(e => e.Deleteddate)
                .HasPrecision(3)
                .HasColumnName("deleteddate");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.HotelId).HasColumnName("hotel_id");
            entity.Property(e => e.Iconimage)
                .HasMaxLength(600)
                .HasColumnName("iconimage");
            entity.Property(e => e.IsReserved).HasColumnName("is_reserved");
            entity.Property(e => e.Isactive).HasColumnName("isactive");
            entity.Property(e => e.RoomTypeId).HasColumnName("room_type_id");
            entity.Property(e => e.Updatedby).HasColumnName("updatedby");
            entity.Property(e => e.Updateddate)
                .HasPrecision(3)
                .HasColumnName("updateddate");
        });

        modelBuilder.Entity<TblRoomimage>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tbl_roomimage");

            entity.Property(e => e.ContentType)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("content_type");
            entity.Property(e => e.Createdby).HasColumnName("createdby");
            entity.Property(e => e.Createddate)
                .HasPrecision(3)
                .HasColumnName("createddate");
            entity.Property(e => e.Deletedby).HasColumnName("deletedby");
            entity.Property(e => e.Deleteddate)
                .HasPrecision(3)
                .HasColumnName("deleteddate");
            entity.Property(e => e.ImageName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("image_name");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(600)
                .IsUnicode(false)
                .HasColumnName("image_url");
            entity.Property(e => e.Isactive).HasColumnName("isactive");
            entity.Property(e => e.RoomId).HasColumnName("room_id");
            entity.Property(e => e.RoomImageId)
                .ValueGeneratedOnAdd()
                .HasColumnName("room_image_id");
            entity.Property(e => e.Updatedby).HasColumnName("updatedby");
            entity.Property(e => e.Updateddate)
                .HasPrecision(3)
                .HasColumnName("updateddate");

            entity.HasOne(d => d.CreatedbyNavigation).WithMany()
                .HasForeignKey(d => d.Createdby)
                .HasConstraintName("FK_tbl_roomimage_tbl_AdminSession");

            entity.HasOne(d => d.DeletedbyNavigation).WithMany()
                .HasForeignKey(d => d.Deletedby)
                .HasConstraintName("FK_tbl_roomimage_tbl_AdminSession2");

            entity.HasOne(d => d.Room).WithMany()
                .HasForeignKey(d => d.RoomId)
                .HasConstraintName("FK_tbl_roomimage_tbl_room");

            entity.HasOne(d => d.UpdatedbyNavigation).WithMany()
                .HasForeignKey(d => d.Updatedby)
                .HasConstraintName("FK_tbl_roomimage_tbl_AdminSession1");
        });

        modelBuilder.Entity<TblRoomtype>(entity =>
        {
            entity.HasKey(e => e.RoomTypeId).HasName("PK__tbl_room__42395E84A0FE114D");

            entity.ToTable("tbl_roomtype");

            entity.Property(e => e.RoomTypeId).HasColumnName("room_type_id");
            entity.Property(e => e.Createdby).HasColumnName("createdby");
            entity.Property(e => e.Createddate)
                .HasPrecision(3)
                .HasColumnName("createddate");
            entity.Property(e => e.Deletedby).HasColumnName("deletedby");
            entity.Property(e => e.Deleteddate)
                .HasPrecision(3)
                .HasColumnName("deleteddate");
            entity.Property(e => e.Isactive).HasColumnName("isactive");
            entity.Property(e => e.RoomType)
                .HasMaxLength(255)
                .HasColumnName("room_type");
            entity.Property(e => e.Updatedby).HasColumnName("updatedby");
            entity.Property(e => e.Updateddate)
                .HasPrecision(3)
                .HasColumnName("updateddate");

            entity.HasOne(d => d.CreatedbyNavigation).WithMany(p => p.TblRoomtypeCreatedbyNavigations)
                .HasForeignKey(d => d.Createdby)
                .HasConstraintName("fk_createdby");

            entity.HasOne(d => d.DeletedbyNavigation).WithMany(p => p.TblRoomtypeDeletedbyNavigations)
                .HasForeignKey(d => d.Deletedby)
                .HasConstraintName("fk_deletedby");

            entity.HasOne(d => d.UpdatedbyNavigation).WithMany(p => p.TblRoomtypeUpdatedbyNavigations)
                .HasForeignKey(d => d.Updatedby)
                .HasConstraintName("fk_updatedby");
        });

        //modelBuilder.Entity<TblState>(entity =>
        //{
        //    entity.HasKey(e => e.StateId);

        //    entity.ToTable("tbl_State");

        //    entity.Property(e => e.StateId)
        //        .ValueGeneratedNever()
        //        .HasColumnName("StateID");
        //    entity.Property(e => e.CountryId).HasColumnName("CountryID");
        //    entity.Property(e => e.StateName)
        //        .HasMaxLength(250)
        //        .IsUnicode(false);

        //    entity.HasOne(d => d.Country).WithMany(p => p.TblStates)
        //        .HasForeignKey(d => d.CountryId)
        //        .HasConstraintName("FK_tbl_State_tbl_Country");
        //});
        modelBuilder.Entity<TblState>(entity =>
        {
            entity.HasKey(e => e.StateId);

            entity.ToTable("tbl_State");

            // Enable identity insert on StateId
            entity.Property(e => e.StateId)
                .ValueGeneratedOnAdd()  // Enable auto-generation for StateId
                .HasColumnName("StateID");
            entity.Property(e => e.IsActive).HasColumnName("IsActive");
            entity.Property(e => e.CountryId).HasColumnName("CountryID");

            entity.Property(e => e.StateName)
                .HasMaxLength(250)
                .IsUnicode(false);

            entity.HasOne(d => d.Country).WithMany(p => p.TblStates)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("FK_tbl_State_tbl_Country");
        });

        modelBuilder.Entity<TblUser>(entity =>
        {
            entity.ToTable("tbl_User");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Address)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.CityId).HasColumnName("CityID");
            entity.Property(e => e.CountryId).HasColumnName("CountryID");
            entity.Property(e => e.EmailId)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EmailID");
            entity.Property(e => e.FullName)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Iv)
                .IsUnicode(false)
                .HasColumnName("iv");
            entity.Property(e => e.Key)
                .IsUnicode(false)
                .HasColumnName("key");
            entity.Property(e => e.MobileNo)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Password).IsUnicode(false);
            entity.Property(e => e.Salt)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("salt");
            entity.Property(e => e.StateId).HasColumnName("StateID");
            entity.Property(e => e.UserId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("UserID");

            entity.HasOne(d => d.City).WithMany(p => p.TblUsers)
                .HasForeignKey(d => d.CityId)
                .HasConstraintName("FK_tbl_User_tbl_city");

            entity.HasOne(d => d.Country).WithMany(p => p.TblUsers)
                .HasForeignKey(d => d.CountryId)
                .HasConstraintName("FK_tbl_User_tbl_Country");

            entity.HasOne(d => d.State).WithMany(p => p.TblUsers)
                .HasForeignKey(d => d.StateId)
                .HasConstraintName("FK_tbl_User_tbl_State");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}