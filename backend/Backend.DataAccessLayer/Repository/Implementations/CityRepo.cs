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
        private static BaseraHotelReservationSystemContext _context;
        public CityRepo(BaseraHotelReservationSystemContext context)
        {
            _context = context;
        }

        public async Task<TblCity> Create(TblCity city)
        {
            await _context.TblCities.AddAsync(city);
            await _context.SaveChangesAsync();
            return city;
        }

        public async Task<TblCity> Delete(long id)
        {
            var tblCity =await _context.TblCities.FindAsync(id);
            _context.TblCities.Remove(tblCity);
            return tblCity;

        }

        public async Task<TblCity> Get(long id)
        {
            return await _context.TblCities.FindAsync(id);
        }

        public async Task<List<TblCity>> GetAll()
        {
            return await _context.TblCities.ToListAsync();
        }

        public async Task<TblCity> Update(long id, TblCity city)
        {
            var tblCity = await _context.TblCities.FindAsync(id);
            if (city != null)
            {
                tblCity.CityName = city.CityName != null ? city.CityName : tblCity.CityName;
                tblCity.StateId = city.StateId != null ? city.StateId : tblCity.StateId;
                await _context.SaveChangesAsync();
                return city;
            }
            else
            {
                return null;
            }

        }
    }
}
