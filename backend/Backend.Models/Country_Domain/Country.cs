using Backend.Domain.User_Domain;
using Backend.Models.State_Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Models.Country_Domain
{
    public class Country
    {
        public long CountryId { get; set; }

        public string? CountryName { get; set; }

        //public virtual ICollection<State> States { get; set; } = new List<State>();

        //public virtual ICollection<User> TblUsers { get; set; } = new List<User>();
    }
}
