using Backend.Domain.User_Domain;
using Backend.Models.Country_Domain;
using Backend.Models.State_Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Models.City_Domain
{
    public class City_Model
    {
        public long CityId { get; set; }

        public string? CityName { get; set; }
        public long? CountryId { get; set; }
        public long? StateId { get; set; }
        public string CountryName { get; set; }
        public string StateName { get; set; }
        public bool IsActive { get; set; }
        public virtual State? State { get; set; }
        public virtual Country? Country { get; set; }
        public virtual ICollection<User> Users { get; set; } = new List<User>();
    }
}
