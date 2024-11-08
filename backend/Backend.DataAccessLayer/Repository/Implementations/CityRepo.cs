using Backend.DataAccessLayer.Context.DBContext;
using Backend.DataAccessLayer.Context.Models;
using Backend.DataAccessLayer.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.DataAccessLayer.Repository.Implementations
{
    public class CityRepo : ICityRepo
    {
        private readonly BaseraHotelReservationSystemContext _context;
        public CityRepo(BaseraHotelReservationSystemContext context)
        {
            _context = context;
        }

        public async Task<TblCity> Create(TblCity city)
        {
            try
            {
                await _context.TblCities.AddAsync(city);
                await _context.SaveChangesAsync();
                return city;
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }

        public async Task<TblCity> Delete(long id)
        {
            var tblCity =await _context.TblCities.FindAsync(id);
            _context.TblCities.Remove(tblCity);
            return tblCity;

        }

        public async Task<TblCity> Get(long id)
        {
            try
            {
                return await _context.TblCities.Where(x => x.CityId == id).Include(x => x.State).Include(x=>x.Country).FirstOrDefaultAsync();
                //return await _context.TblCities.Where(x => x.CityId == id).FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }

        public async Task<List<TblCity>> GetAll()
        {
            return await _context.TblCities.Include(x => x.State).Include(x=>x.Country).ToListAsync();
        }

        public async Task<List<TblCity>> GetCitiesBasedOnStateId(long id)
        {
            return await _context.TblCities.Include(x=>x.State).Where(x=>x.StateId==id).ToListAsync();  
        }

        public async Task<TblCity> Update(long id, TblCity city)
        {
            try
            {
                
                var tblCity =  _context.TblCities.Find(id);

                if (city != null&&tblCity!=null)
                {
                    tblCity.CityName = city.CityName != null ? city.CityName : tblCity.CityName;
                    tblCity.StateId = city.StateId != null ? city.StateId : tblCity.StateId;
                    tblCity.CountryId = city.CountryId != null ? city.CountryId : tblCity.CountryId;
                    await _context.SaveChangesAsync();
                    return city;
                }
                else
                {
                    return null;
                }
               
            }
            catch (Exception ex)
            {

                throw;
            }
            

        }
    }
}
