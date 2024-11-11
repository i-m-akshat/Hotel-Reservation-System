using Backend.DataAccessLayer.Repository.Implementations;
using Backend.DataAccessLayer.Repository.Interfaces;
using Backend.Models.City_Domain;
using Backend.Services.Interfaces;
using Backend.Services.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Services.Implementatios
{
    public class CityService : ICityService
    {
        private static ICityRepo _repo;
        public CityService(ICityRepo repo)
        {
            _repo = repo;
        }
        public async Task<City_Model> Create(City_Model city)
        {
            var res=await _repo.Create(city.ToTblCity());
            return res.ToCityModel_withoutStateName();
            
        }

        public async Task<City_Model> Delete(long id)
        {
            var res = await _repo.Delete(id);
            return res.ToCityModel_withoutStateName();

        }

        public async Task<List<City_Model>> Get()
        {
            var res = await _repo.GetAll();
            return res.Select(x=>x.ToCityModel()).ToList();
        }

        public async Task<City_Model> GetById(long id)
        {
            try
            {
                var res = await _repo.Get(id);
                return res.ToCityModel_withoutStateName();
            }
            catch (Exception)
            {

                throw;
            }
               
        }

        public async Task<City_Model> Update(City_Model city,long id)
        {
            var res = await _repo.Update(id, city.ToTblCity());
            return res.ToCityModel_withoutStateName();
        }
    }
}
