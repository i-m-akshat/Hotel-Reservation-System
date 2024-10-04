using Backend.DataAccessLayer.Context.Models;
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
        Task<List<Country>> GetAll();
        Task<Country> Get(long id);
        Task<Country> Create(Country country);
        Task<Country> Update(Country country, long id );
        Task<Country> Delete(long id);
    }
}
