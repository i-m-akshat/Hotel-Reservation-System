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
    public class HotelRepo : IHotelRepo
    {
        private static BaseraHotelReservationSystemContext _context;
        public HotelRepo(BaseraHotelReservationSystemContext context)
        {
            _context = context;   
        }
        public async Task<TblHotel> CreateHotel(TblHotel hotel)
        {
            await _context.TblHotels.AddAsync(hotel);
            await _context.SaveChangesAsync();
            return hotel;   
        }

        public async Task<TblHotel> DeleteHotel(long id)
        {
           TblHotel _tbl=await _context.TblHotels.Where(x=>x.HotelId==id).FirstOrDefaultAsync();
            if (_tbl != null)
            {
                _tbl.IsActive = false;
                await _context.SaveChangesAsync();
                return _tbl;
            }
            else
                return null;
        }

        public async Task<List<TblHotel>> GetAllHotels()
        {
            return await _context.TblHotels.Where(x=>x.IsActive==true).ToListAsync();
        }

        public async Task<TblHotel> GetHotelsByid(long id)
        {
            var _tbl = await _context.TblHotels.FindAsync(id);
            if (_tbl != null)
            {


                return _tbl;
            }
            else
                return null;
        }

        public async Task<TblHotel> UpdateHotel(TblHotel hotel, long id)
        {
            var _tbl=await _context.TblHotels.Where(x=>x.HotelId == id).FirstOrDefaultAsync();
            if (_tbl != null) {
                _context.SaveChangesAsync();
            
            }
            return _tbl;

        }
    }
}
