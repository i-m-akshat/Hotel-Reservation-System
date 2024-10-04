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

        public async Task<Country> Delete(long id)
        {
           var res= await _repo.Delete(id);
            return res.toCountry();
        }

        public async Task<Country> Get(long id)
        {
            var res=await _repo.Get(id);
            return res.toCountry();
        }

        public async Task<List<Country>> GetAll()
        {
          var countries=await _repo.GetAll();
            return countries.Select(x => x.toCountry()).ToList();
        }

        public async Task<Country> Update(Country country, long id)
        {
            var res = await _repo.Update(country.ToTblCountry(), id);
            return res.toCountry(); 
        }
    }
}
