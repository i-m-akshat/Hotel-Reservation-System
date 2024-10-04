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
    public class CountryRepo : ICountryRepo
    {
        private readonly BaseraHotelReservationSystemContext _context;
        public CountryRepo(BaseraHotelReservationSystemContext context)
        {
            _context = context;
        }
        public async Task<TblCountry> Create(TblCountry country)
        {
            await _context.TblCountries.AddAsync(country);   
            await _context.SaveChangesAsync();
            return country;
        }

        public async Task<TblCountry> Delete(long id)
        {
            var tblCountry=await _context.TblCountries.FindAsync(id);
            if (tblCountry != null) {
                _context.TblCountries.Remove(tblCountry);
                await _context.SaveChangesAsync();
                return tblCountry;  
            } else { return null; }
        }

        public async Task<TblCountry> Get(long id)
        {
            TblCountry tblCountry =await _context.TblCountries.FindAsync(id);
            return tblCountry;
        }

        public async Task<List<TblCountry>> GetAll()
        {
           return await _context.TblCountries.ToListAsync();
        }

        public async Task<TblCountry> Update(TblCountry country, long id)
        {
            var tblCountry =await _context.TblCountries.FindAsync(id);
            if (tblCountry != null)
            {
                tblCountry.CountryName = country.CountryName!=null?country.CountryName:tblCountry.CountryName;
                _context.TblCountries.Update(tblCountry);
                _context.SaveChangesAsync();
                return tblCountry;  
            }
            else
            {
                return null;
            }
        }
    }
}
