using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class Migartion29Sept2024 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tbl_AdminSession",
                columns: table => new
                {
                    session_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Admin_id = table.Column<long>(type: "bigint", nullable: true),
                    Session_start = table.Column<DateTime>(type: "datetime", nullable: true),
                    Session_end = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeviceType = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Devicelocation = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    IP_Address = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_AdminSession", x => x.session_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_city",
                columns: table => new
                {
                    CityId = table.Column<long>(type: "bigint", nullable: false),
                    CityName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    StateID = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_city", x => x.CityId);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Country",
                columns: table => new
                {
                    countryId = table.Column<long>(type: "bigint", nullable: false),
                    CountryName = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Country", x => x.countryId);
                });

            migrationBuilder.CreateTable(
                name: "tbl_reservation_event_status",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    reservation_id = table.Column<long>(type: "bigint", nullable: true),
                    reservatioin_Status_id = table.Column<long>(type: "bigint", nullable: true),
                    details = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    createdDate = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_reservation_event_status", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_room",
                columns: table => new
                {
                    room_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    hotel_id = table.Column<long>(type: "bigint", nullable: true),
                    room_type_id = table.Column<long>(type: "bigint", nullable: true),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    current_price = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    is_reserved = table.Column<bool>(type: "bit", nullable: true),
                    isactive = table.Column<bool>(type: "bit", nullable: true),
                    createddate = table.Column<DateTime>(type: "datetime2(3)", precision: 3, nullable: true),
                    createdby = table.Column<long>(type: "bigint", nullable: true),
                    updateddate = table.Column<DateTime>(type: "datetime2(3)", precision: 3, nullable: true),
                    updatedby = table.Column<long>(type: "bigint", nullable: true),
                    deleteddate = table.Column<DateTime>(type: "datetime2(3)", precision: 3, nullable: true),
                    deletedby = table.Column<long>(type: "bigint", nullable: true),
                    bannerimage = table.Column<string>(type: "nvarchar(600)", maxLength: 600, nullable: true),
                    iconimage = table.Column<string>(type: "nvarchar(600)", maxLength: 600, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbl_room__19675A8A22DD1E4B", x => x.room_id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_State",
                columns: table => new
                {
                    StateID = table.Column<long>(type: "bigint", nullable: false),
                    StateName = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    CountryID = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_State", x => x.StateID);
                });

            migrationBuilder.CreateTable(
                name: "tbl_Admin",
                columns: table => new
                {
                    AdminID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adminname = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    FullName = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    Isactive = table.Column<bool>(type: "bit", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    EmailID = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Password = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    Createdby = table.Column<long>(type: "bigint", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    CountryID = table.Column<long>(type: "bigint", nullable: true),
                    StateID = table.Column<long>(type: "bigint", nullable: true),
                    CityID = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Admin", x => x.AdminID);
                    table.ForeignKey(
                        name: "FK_tbl_Admin_tbl_AdminSession",
                        column: x => x.Createdby,
                        principalTable: "tbl_AdminSession",
                        principalColumn: "session_id");
                    table.ForeignKey(
                        name: "FK_tbl_Admin_tbl_AdminSession1",
                        column: x => x.DeletedBy,
                        principalTable: "tbl_AdminSession",
                        principalColumn: "session_id");
                    table.ForeignKey(
                        name: "FK_tbl_Admin_tbl_AdminSession2",
                        column: x => x.UpdatedBy,
                        principalTable: "tbl_AdminSession",
                        principalColumn: "session_id");
                });

            migrationBuilder.CreateTable(
                name: "tbl_channel",
                columns: table => new
                {
                    channel_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    channel_name = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: true),
                    details = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    createddate = table.Column<DateTime>(type: "datetime2(3)", precision: 3, nullable: true),
                    createdby = table.Column<long>(type: "bigint", nullable: true),
                    updateddate = table.Column<DateTime>(type: "datetime2(3)", precision: 3, nullable: true),
                    updatedby = table.Column<long>(type: "bigint", nullable: true),
                    deleteddate = table.Column<DateTime>(type: "datetime2(3)", precision: 3, nullable: true),
                    deletedby = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_channel", x => x.channel_id);
                    table.ForeignKey(
                        name: "FK_tbl_channel_tbl_AdminSession",
                        column: x => x.createdby,
                        principalTable: "tbl_AdminSession",
                        principalColumn: "session_id");
                    table.ForeignKey(
                        name: "FK_tbl_channel_tbl_AdminSession1",
                        column: x => x.deletedby,
                        principalTable: "tbl_AdminSession",
                        principalColumn: "session_id");
                    table.ForeignKey(
                        name: "FK_tbl_channel_tbl_AdminSession2",
                        column: x => x.updatedby,
                        principalTable: "tbl_AdminSession",
                        principalColumn: "session_id");
                });

            migrationBuilder.CreateTable(
                name: "tbl_Hotel",
                columns: table => new
                {
                    HotelID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HotelName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Hotel_Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    CountryId = table.Column<long>(type: "bigint", nullable: false),
                    StateId = table.Column<long>(type: "bigint", nullable: true),
                    CityID = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    CreatedBy = table.Column<long>(type: "bigint", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Category_Id = table.Column<long>(type: "bigint", nullable: true),
                    Icon_Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    Banner_Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    longitude = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    latitude = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Hotel", x => x.HotelID);
                    table.ForeignKey(
                        name: "FK_tbl_Hotel_tbl_AdminSession",
                        column: x => x.CreatedBy,
                        principalTable: "tbl_AdminSession",
                        principalColumn: "session_id");
                    table.ForeignKey(
                        name: "FK_tbl_Hotel_tbl_AdminSession1",
                        column: x => x.UpdatedBy,
                        principalTable: "tbl_AdminSession",
                        principalColumn: "session_id");
                    table.ForeignKey(
                        name: "FK_tbl_Hotel_tbl_AdminSession2",
                        column: x => x.DeletedBy,
                        principalTable: "tbl_AdminSession",
                        principalColumn: "session_id");
                });

            migrationBuilder.CreateTable(
                name: "tbl_reservation_status",
                columns: table => new
                {
                    reservation_status_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    status = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    createdDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    createdby = table.Column<long>(type: "bigint", nullable: true),
                    updatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Updatedby = table.Column<long>(type: "bigint", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_reservation_status", x => x.reservation_status_id);
                    table.ForeignKey(
                        name: "FK_tbl_reservation_status_tbl_AdminSession",
                        column: x => x.Updatedby,
                        principalTable: "tbl_AdminSession",
                        principalColumn: "session_id");
                    table.ForeignKey(
                        name: "FK_tbl_reservation_status_tbl_AdminSession1",
                        column: x => x.DeletedBy,
                        principalTable: "tbl_AdminSession",
                        principalColumn: "session_id");
                    table.ForeignKey(
                        name: "FK_tbl_reservation_status_tbl_AdminSession2",
                        column: x => x.createdby,
                        principalTable: "tbl_AdminSession",
                        principalColumn: "session_id");
                });

            migrationBuilder.CreateTable(
                name: "tbl_Role",
                columns: table => new
                {
                    RoleID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Role = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Createdby = table.Column<long>(type: "bigint", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Deletedby = table.Column<long>(type: "bigint", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Role", x => x.RoleID);
                    table.ForeignKey(
                        name: "FK_tbl_Role_tbl_AdminSession",
                        column: x => x.Createdby,
                        principalTable: "tbl_AdminSession",
                        principalColumn: "session_id");
                    table.ForeignKey(
                        name: "FK_tbl_Role_tbl_AdminSession1",
                        column: x => x.Deletedby,
                        principalTable: "tbl_AdminSession",
                        principalColumn: "session_id");
                    table.ForeignKey(
                        name: "FK_tbl_Role_tbl_AdminSession2",
                        column: x => x.UpdatedBy,
                        principalTable: "tbl_AdminSession",
                        principalColumn: "session_id");
                });

            migrationBuilder.CreateTable(
                name: "tbl_roomtype",
                columns: table => new
                {
                    room_type_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    room_type = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    isactive = table.Column<bool>(type: "bit", nullable: true),
                    createddate = table.Column<DateTime>(type: "datetime2(3)", precision: 3, nullable: true),
                    createdby = table.Column<long>(type: "bigint", nullable: true),
                    updateddate = table.Column<DateTime>(type: "datetime2(3)", precision: 3, nullable: true),
                    updatedby = table.Column<long>(type: "bigint", nullable: true),
                    deleteddate = table.Column<DateTime>(type: "datetime2(3)", precision: 3, nullable: true),
                    deletedby = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbl_room__42395E84A0FE114D", x => x.room_type_id);
                    table.ForeignKey(
                        name: "fk_createdby",
                        column: x => x.createdby,
                        principalTable: "tbl_AdminSession",
                        principalColumn: "session_id");
                    table.ForeignKey(
                        name: "fk_deletedby",
                        column: x => x.deletedby,
                        principalTable: "tbl_AdminSession",
                        principalColumn: "session_id");
                    table.ForeignKey(
                        name: "fk_updatedby",
                        column: x => x.updatedby,
                        principalTable: "tbl_AdminSession",
                        principalColumn: "session_id");
                });

            migrationBuilder.CreateTable(
                name: "tbl_ReservedRooms",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    reservation_id = table.Column<long>(type: "bigint", nullable: true),
                    room_id = table.Column<int>(type: "int", nullable: true),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_ReservedRooms", x => x.id);
                    table.ForeignKey(
                        name: "FK_tbl_ReservedRooms_tbl_ReservedRooms",
                        column: x => x.room_id,
                        principalTable: "tbl_room",
                        principalColumn: "room_id");
                });

            migrationBuilder.CreateTable(
                name: "tbl_roomimage",
                columns: table => new
                {
                    room_image_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    room_id = table.Column<int>(type: "int", nullable: true),
                    image_name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    image_url = table.Column<string>(type: "varchar(600)", unicode: false, maxLength: 600, nullable: true),
                    content_type = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    isactive = table.Column<bool>(type: "bit", nullable: true),
                    createddate = table.Column<DateTime>(type: "datetime2(3)", precision: 3, nullable: true),
                    createdby = table.Column<long>(type: "bigint", nullable: true),
                    updateddate = table.Column<DateTime>(type: "datetime2(3)", precision: 3, nullable: true),
                    updatedby = table.Column<long>(type: "bigint", nullable: true),
                    deleteddate = table.Column<DateTime>(type: "datetime2(3)", precision: 3, nullable: true),
                    deletedby = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_tbl_roomimage_tbl_AdminSession",
                        column: x => x.createdby,
                        principalTable: "tbl_AdminSession",
                        principalColumn: "session_id");
                    table.ForeignKey(
                        name: "FK_tbl_roomimage_tbl_AdminSession1",
                        column: x => x.updatedby,
                        principalTable: "tbl_AdminSession",
                        principalColumn: "session_id");
                    table.ForeignKey(
                        name: "FK_tbl_roomimage_tbl_AdminSession2",
                        column: x => x.deletedby,
                        principalTable: "tbl_AdminSession",
                        principalColumn: "session_id");
                    table.ForeignKey(
                        name: "FK_tbl_roomimage_tbl_room",
                        column: x => x.room_id,
                        principalTable: "tbl_room",
                        principalColumn: "room_id");
                });

            migrationBuilder.CreateTable(
                name: "tbl_User",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserID = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    FullName = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    Address = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    StateID = table.Column<long>(type: "bigint", nullable: true),
                    CityID = table.Column<long>(type: "bigint", nullable: true),
                    CountryID = table.Column<long>(type: "bigint", nullable: true),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    EmailID = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    MobileNo = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: true),
                    Password = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    salt = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    key = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    iv = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_User", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tbl_User_tbl_Country",
                        column: x => x.CountryID,
                        principalTable: "tbl_Country",
                        principalColumn: "countryId");
                    table.ForeignKey(
                        name: "FK_tbl_User_tbl_State",
                        column: x => x.StateID,
                        principalTable: "tbl_State",
                        principalColumn: "StateID");
                    table.ForeignKey(
                        name: "FK_tbl_User_tbl_city",
                        column: x => x.CityID,
                        principalTable: "tbl_city",
                        principalColumn: "CityId");
                });

            migrationBuilder.CreateTable(
                name: "tbl_channelused",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false),
                    channel_id = table.Column<int>(type: "int", nullable: true),
                    room_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_channelused", x => x.id);
                    table.ForeignKey(
                        name: "FK_tbl_channelused_tbl_channel",
                        column: x => x.channel_id,
                        principalTable: "tbl_channel",
                        principalColumn: "channel_id");
                    table.ForeignKey(
                        name: "FK_tbl_channelused_tbl_room",
                        column: x => x.id,
                        principalTable: "tbl_room",
                        principalColumn: "room_id");
                });

            migrationBuilder.CreateTable(
                name: "tbl_hotelcontactdetails",
                columns: table => new
                {
                    contact_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    hotel_id = table.Column<long>(type: "bigint", nullable: true),
                    hotel_contact_type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    hotel_contact_value = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    isprimary = table.Column<bool>(type: "bit", nullable: true),
                    isactive = table.Column<bool>(type: "bit", nullable: true),
                    createddate = table.Column<DateTime>(type: "datetime2(3)", precision: 3, nullable: true),
                    createdby = table.Column<long>(type: "bigint", nullable: true),
                    updateddate = table.Column<DateTime>(type: "datetime2(3)", precision: 3, nullable: true),
                    updatedby = table.Column<long>(type: "bigint", nullable: true),
                    deleteddate = table.Column<DateTime>(type: "datetime2(3)", precision: 3, nullable: true),
                    deletedby = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbl_hote__024E7A8656FE4844", x => x.contact_id);
                    table.ForeignKey(
                        name: "FK_tbl_hotelcontactdetails_tbl_AdminSession",
                        column: x => x.deletedby,
                        principalTable: "tbl_AdminSession",
                        principalColumn: "session_id");
                    table.ForeignKey(
                        name: "FK_tbl_hotelcontactdetails_tbl_AdminSession1",
                        column: x => x.createdby,
                        principalTable: "tbl_AdminSession",
                        principalColumn: "session_id");
                    table.ForeignKey(
                        name: "FK_tbl_hotelcontactdetails_tbl_AdminSession2",
                        column: x => x.updatedby,
                        principalTable: "tbl_AdminSession",
                        principalColumn: "session_id");
                    table.ForeignKey(
                        name: "FK_tbl_hotelcontactdetails_tbl_Hotel",
                        column: x => x.hotel_id,
                        principalTable: "tbl_Hotel",
                        principalColumn: "HotelID");
                });

            migrationBuilder.CreateTable(
                name: "tbl_hotelimage",
                columns: table => new
                {
                    hotel_image_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    hotel_id = table.Column<long>(type: "bigint", nullable: true),
                    image_name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    image_url = table.Column<string>(type: "nvarchar(600)", maxLength: 600, nullable: true),
                    content_type = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    isactive = table.Column<bool>(type: "bit", nullable: true),
                    createddate = table.Column<DateTime>(type: "datetime2(3)", precision: 3, nullable: true),
                    createdby = table.Column<long>(type: "bigint", nullable: true),
                    updateddate = table.Column<DateTime>(type: "datetime2(3)", precision: 3, nullable: true),
                    updatedby = table.Column<long>(type: "bigint", nullable: true),
                    deleteddate = table.Column<DateTime>(type: "datetime2(3)", precision: 3, nullable: true),
                    deletedby = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbl_hote__066CE50E30442154", x => x.hotel_image_id);
                    table.ForeignKey(
                        name: "FK_tbl_hotelimage_tbl_AdminSession",
                        column: x => x.createdby,
                        principalTable: "tbl_AdminSession",
                        principalColumn: "session_id");
                    table.ForeignKey(
                        name: "FK_tbl_hotelimage_tbl_AdminSession1",
                        column: x => x.updatedby,
                        principalTable: "tbl_AdminSession",
                        principalColumn: "session_id");
                    table.ForeignKey(
                        name: "FK_tbl_hotelimage_tbl_AdminSession2",
                        column: x => x.deletedby,
                        principalTable: "tbl_AdminSession",
                        principalColumn: "session_id");
                    table.ForeignKey(
                        name: "FK_tbl_hotelimage_tbl_Hotel",
                        column: x => x.hotel_id,
                        principalTable: "tbl_Hotel",
                        principalColumn: "HotelID");
                });

            migrationBuilder.CreateTable(
                name: "tbl_Access",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false),
                    RoleID = table.Column<long>(type: "bigint", nullable: true),
                    AccessURL = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true),
                    AccessProvidedBy = table.Column<long>(type: "bigint", nullable: true),
                    AccessProvidedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    IconUrl = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_Access", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tbl_Access_tbl_Admin",
                        column: x => x.AccessProvidedBy,
                        principalTable: "tbl_AdminSession",
                        principalColumn: "session_id");
                    table.ForeignKey(
                        name: "FK_tbl_Access_tbl_Role",
                        column: x => x.RoleID,
                        principalTable: "tbl_Role",
                        principalColumn: "RoleID");
                });

            migrationBuilder.CreateTable(
                name: "tbl_reservation",
                columns: table => new
                {
                    reservation_id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<long>(type: "bigint", nullable: true),
                    check_in_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    check_Out_date = table.Column<DateTime>(type: "datetime", nullable: true),
                    total_price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    createddate = table.Column<DateTime>(type: "datetime", nullable: true),
                    createdby = table.Column<long>(type: "bigint", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    Updatedby = table.Column<long>(type: "bigint", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    DeletedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_reservation", x => x.reservation_id);
                    table.ForeignKey(
                        name: "FK_tbl_reservation_tbl_AdminSession",
                        column: x => x.Updatedby,
                        principalTable: "tbl_AdminSession",
                        principalColumn: "session_id");
                    table.ForeignKey(
                        name: "FK_tbl_reservation_tbl_AdminSession1",
                        column: x => x.createdby,
                        principalTable: "tbl_AdminSession",
                        principalColumn: "session_id");
                    table.ForeignKey(
                        name: "FK_tbl_reservation_tbl_AdminSession2",
                        column: x => x.DeletedBy,
                        principalTable: "tbl_AdminSession",
                        principalColumn: "session_id");
                    table.ForeignKey(
                        name: "FK_tbl_reservation_tbl_User",
                        column: x => x.user_id,
                        principalTable: "tbl_User",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "tbl_review",
                columns: table => new
                {
                    review_id = table.Column<long>(type: "bigint", nullable: false),
                    hotel_id = table.Column<long>(type: "bigint", nullable: true),
                    rating = table.Column<int>(type: "int", nullable: true),
                    comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    reviewedDate = table.Column<DateTime>(type: "datetime", nullable: true),
                    reviewedBy = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_review", x => x.review_id);
                    table.ForeignKey(
                        name: "FK_tbl_review_tbl_User",
                        column: x => x.review_id,
                        principalTable: "tbl_User",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "tbl_invoice",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<long>(type: "bigint", nullable: true),
                    reservation_id = table.Column<long>(type: "bigint", nullable: true),
                    amount = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    issueddate = table.Column<DateTime>(type: "datetime2(3)", precision: 3, nullable: true),
                    paiddate = table.Column<DateTime>(type: "datetime2(3)", precision: 3, nullable: true),
                    cancelleddate = table.Column<DateTime>(type: "datetime2(3)", precision: 3, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__tbl_invo__3213E83F1BD14D80", x => x.id);
                    table.ForeignKey(
                        name: "FK_tbl_invoice_tbl_User",
                        column: x => x.user_id,
                        principalTable: "tbl_User",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_tbl_invoice_tbl_reservation",
                        column: x => x.reservation_id,
                        principalTable: "tbl_reservation",
                        principalColumn: "reservation_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Access_AccessProvidedBy",
                table: "tbl_Access",
                column: "AccessProvidedBy");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Access_RoleID",
                table: "tbl_Access",
                column: "RoleID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Admin_Createdby",
                table: "tbl_Admin",
                column: "Createdby");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Admin_DeletedBy",
                table: "tbl_Admin",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Admin_UpdatedBy",
                table: "tbl_Admin",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_channel_createdby",
                table: "tbl_channel",
                column: "createdby");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_channel_deletedby",
                table: "tbl_channel",
                column: "deletedby");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_channel_updatedby",
                table: "tbl_channel",
                column: "updatedby");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_channelused_channel_id",
                table: "tbl_channelused",
                column: "channel_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Hotel_CreatedBy",
                table: "tbl_Hotel",
                column: "CreatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Hotel_DeletedBy",
                table: "tbl_Hotel",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Hotel_UpdatedBy",
                table: "tbl_Hotel",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_hotelcontactdetails_createdby",
                table: "tbl_hotelcontactdetails",
                column: "createdby");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_hotelcontactdetails_deletedby",
                table: "tbl_hotelcontactdetails",
                column: "deletedby");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_hotelcontactdetails_hotel_id",
                table: "tbl_hotelcontactdetails",
                column: "hotel_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_hotelcontactdetails_updatedby",
                table: "tbl_hotelcontactdetails",
                column: "updatedby");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_hotelimage_createdby",
                table: "tbl_hotelimage",
                column: "createdby");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_hotelimage_deletedby",
                table: "tbl_hotelimage",
                column: "deletedby");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_hotelimage_hotel_id",
                table: "tbl_hotelimage",
                column: "hotel_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_hotelimage_updatedby",
                table: "tbl_hotelimage",
                column: "updatedby");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_invoice_reservation_id",
                table: "tbl_invoice",
                column: "reservation_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_invoice_user_id",
                table: "tbl_invoice",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_reservation_createdby",
                table: "tbl_reservation",
                column: "createdby");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_reservation_DeletedBy",
                table: "tbl_reservation",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_reservation_Updatedby",
                table: "tbl_reservation",
                column: "Updatedby");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_reservation_user_id",
                table: "tbl_reservation",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_reservation_status_createdby",
                table: "tbl_reservation_status",
                column: "createdby");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_reservation_status_DeletedBy",
                table: "tbl_reservation_status",
                column: "DeletedBy");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_reservation_status_Updatedby",
                table: "tbl_reservation_status",
                column: "Updatedby");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_ReservedRooms_room_id",
                table: "tbl_ReservedRooms",
                column: "room_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Role_Createdby",
                table: "tbl_Role",
                column: "Createdby");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Role_Deletedby",
                table: "tbl_Role",
                column: "Deletedby");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_Role_UpdatedBy",
                table: "tbl_Role",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_roomimage_createdby",
                table: "tbl_roomimage",
                column: "createdby");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_roomimage_deletedby",
                table: "tbl_roomimage",
                column: "deletedby");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_roomimage_room_id",
                table: "tbl_roomimage",
                column: "room_id");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_roomimage_updatedby",
                table: "tbl_roomimage",
                column: "updatedby");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_roomtype_createdby",
                table: "tbl_roomtype",
                column: "createdby");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_roomtype_deletedby",
                table: "tbl_roomtype",
                column: "deletedby");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_roomtype_updatedby",
                table: "tbl_roomtype",
                column: "updatedby");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_User_CityID",
                table: "tbl_User",
                column: "CityID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_User_CountryID",
                table: "tbl_User",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_User_StateID",
                table: "tbl_User",
                column: "StateID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_Access");

            migrationBuilder.DropTable(
                name: "tbl_Admin");

            migrationBuilder.DropTable(
                name: "tbl_channelused");

            migrationBuilder.DropTable(
                name: "tbl_hotelcontactdetails");

            migrationBuilder.DropTable(
                name: "tbl_hotelimage");

            migrationBuilder.DropTable(
                name: "tbl_invoice");

            migrationBuilder.DropTable(
                name: "tbl_reservation_event_status");

            migrationBuilder.DropTable(
                name: "tbl_reservation_status");

            migrationBuilder.DropTable(
                name: "tbl_ReservedRooms");

            migrationBuilder.DropTable(
                name: "tbl_review");

            migrationBuilder.DropTable(
                name: "tbl_roomimage");

            migrationBuilder.DropTable(
                name: "tbl_roomtype");

            migrationBuilder.DropTable(
                name: "tbl_Role");

            migrationBuilder.DropTable(
                name: "tbl_channel");

            migrationBuilder.DropTable(
                name: "tbl_Hotel");

            migrationBuilder.DropTable(
                name: "tbl_reservation");

            migrationBuilder.DropTable(
                name: "tbl_room");

            migrationBuilder.DropTable(
                name: "tbl_AdminSession");

            migrationBuilder.DropTable(
                name: "tbl_User");

            migrationBuilder.DropTable(
                name: "tbl_Country");

            migrationBuilder.DropTable(
                name: "tbl_State");

            migrationBuilder.DropTable(
                name: "tbl_city");
        }
    }
}
