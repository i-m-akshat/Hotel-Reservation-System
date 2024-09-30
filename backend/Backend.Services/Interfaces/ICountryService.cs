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
        Task<Country> Get(int id);
        Task<Country> Create(Country country);
        Task<Country> Update(Country country);
        Task<Country> Delete(int id);
    }
}
