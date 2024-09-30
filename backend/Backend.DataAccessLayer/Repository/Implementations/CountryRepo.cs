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

        public Task<TblCountry> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<TblCountry> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TblCountry>> GetAll()
        {
           return await _context.TblCountries.ToListAsync();
        }

        public Task<TblCountry> Update(TblCountry country)
        {
            throw new NotImplementedException();
        }
    }
}
