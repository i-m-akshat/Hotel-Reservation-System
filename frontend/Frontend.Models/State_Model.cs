using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.Models
{
    public class State_Model
    {
        public long StateId { get; set; }
        public string StateName { get; set; }
        public long CountryId { get; set; } 
        public string CountryName { get; set; }
        public bool IsActive { get; set; }
    }
    public class State_DTO
    {
        public int stateid { get; set; }
        public string statename { get; set; }
        public long countryid { get; set; }
        public string countryname { get; set; }
    }
}
