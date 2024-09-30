using Backend.DataAccessLayer.Repository.Interfaces;
using Backend.Models.Country_Domain;
using Backend.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.Services.Mapper;

namespace Backend.Services.Implementatios
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepo _repo;
        public CountryService(ICountryRepo repo)
        {
            _repo = repo;   
        }
        public async Task<Country> Create(Country country)
        {
            var tblCountry = country.ToTblCountry();   
            var _country = await _repo.Create(tblCountry);
            return _country.toCountry();
        }

        public Task<Country> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Country> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Country>> GetAll()
        {
          var countries=await _repo.GetAll();
            return countries.Select(x => x.toCountry()).ToList();
        }

        public Task<Country> Update(Country country)
        {
            throw new NotImplementedException();
        }
    }
}
