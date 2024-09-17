

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Domain.Invoice_Domain;
using Backend.Domain.Reservation_Domain;
namespace Backend.Domain.User_Domain
{
    public class User
    {
        public long Id { get; set; }

        public string? UserId { get; set; }

        public string? FullName { get; set; }

        public string? Address { get; set; }

        public long? StateId { get; set; }
        public string StateName { get;set; }

        public long? CityId { get; set; }
        public string CityName { get; set; }    
        public long? CountryId { get; set; }
        public string CountryName { get; set; } 

        public byte[]? Image { get; set; }

        public string? EmailId { get; set; }

        public string? MobileNo { get; set; }

        public string? Password { get; set; }

        public string? Salt { get; set; }
        public string key { get; set; }
        public string iv { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

        public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();

        //public virtual Review? TblReview { get; set; }

    }
}
