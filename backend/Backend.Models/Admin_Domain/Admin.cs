﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Models.Admin_Domain
{
    public class Admin
    {
        public long AdminId { get; set; }

        public string? Adminname { get; set; }

        public string? FullName { get; set; }

        public bool? Isactive { get; set; }

        public string? Address { get; set; }
        public long RoleID { get; set; }
        public byte[]? Image { get; set; }

        public string? PhoneNumber { get; set; }

        public string? EmailId { get; set; }

        public string? Password { get; set; }

        public long? Createdby { get; set; }

        public DateTime? CreatedDate { get; set; }

        public long? UpdatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public long? DeletedBy { get; set; }

        public DateTime? DeletedDate { get; set; }

        public long? CountryId { get; set; }
        public string? CountryName { get; set; }

        public long? StateId { get; set; }
        public string StateName { get; set; }

        public long? CityId { get; set; }
        public string CityName { get; set; }

        public virtual AdminSession? CreatedbyNavigation { get; set; }

        public virtual AdminSession? DeletedByNavigation { get; set; }

        public virtual AdminSession? UpdatedByNavigation { get; set; }

    }
}
