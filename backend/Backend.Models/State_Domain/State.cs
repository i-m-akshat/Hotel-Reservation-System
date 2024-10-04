using Backend.Domain.User_Domain;
using Backend.Models.City_Domain;
using Backend.Models.Country_Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Models.State_Domain
{
    public class State
    {
        public long StateId { get; set; }

        public string? StateName { get; set; }
        public string? CountryName { get; set; }    
        public long? CountryId { get; set; }
        public virtual Country? Country { get; set; }

        public virtual ICollection<City> Cities { get; set; } = new List<City>();
        public virtual ICollection<User> Users { get; set; } = new List<User>();
    }
}
