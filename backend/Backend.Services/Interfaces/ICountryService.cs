using Backend.Models.Country_Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Services.Interfaces
{
    public interface ICountryService
    {
        List<Country> GetAll();
        Country Get(int id);
        void Create(Country _country);
        void Update(Country _country);
        void Delete(int id);
    }
}
