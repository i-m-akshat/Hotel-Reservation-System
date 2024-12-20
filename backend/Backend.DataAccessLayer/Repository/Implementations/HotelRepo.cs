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
            hotel.CreatedBy = null;
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
                _tbl.DeletedDate = DateTime.Now;
                await _context.SaveChangesAsync();
                return _tbl;
            }
            else
                return null;
        }

        public async Task<List<TblHotel>> GetAllHotels()
        {
            return await _context.TblHotels.AsNoTracking().Include(x => x.Country).Include(x => x.State).Include(x => x.City).Select(x=>new TblHotel
            {
                Address=x.Address,
                CityId=x.CityId,
                StateId=x.StateId,
                CountryId=x.CountryId,
                HotelDescription=x.HotelDescription,
                HotelName=x.HotelName,
                Latitude=x.Latitude,
                Longitude=x.Longitude,
                HotelId=x.HotelId,
                IsActive=x.IsActive,
                CreatedBy=x.CreatedBy,
                CreatedDate=x.CreatedDate,
                UpdatedBy=x.UpdatedBy,
                UpdatedDate=x.UpdatedDate,
                DeletedBy=x.DeletedBy,
                DeletedDate=x.DeletedDate,
                State=x.State,
                City=x.City,
                Country=x.Country
                
            }).Where(x=>x.IsActive==true).ToListAsync();
        }

        public async Task<TblHotel> GetHotelsByid(long id)
        {
            var _tbl = await _context.TblHotels.AsNoTracking().Include(x => x.State).Include(x => x.Country).Include(x => x.City).Where(x=>x.HotelId==id).FirstOrDefaultAsync();
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
                _tbl.Longitude = hotel.Longitude!=null?hotel.Longitude:_tbl.Longitude;
                _tbl.Latitude = hotel.Latitude!=null?hotel.Latitude:_tbl.Latitude;
                _tbl.CountryId = hotel.CountryId!=null?hotel.CountryId:_tbl.CountryId;
                _tbl.CityId = hotel.CityId!=null?hotel.CityId:_tbl. CityId;
                _tbl.StateId=hotel.StateId!=null?hotel.StateId:_tbl.StateId;
                _tbl.Address=hotel.Address!=null?hotel.Address:_tbl.Address;
                _tbl.HotelName=hotel.HotelName!=null?hotel.HotelName:_tbl.HotelName;
                _tbl.HotelDescription=hotel.HotelDescription!=null?hotel.HotelDescription:_tbl. HotelDescription;
                _tbl.UpdatedBy=hotel.UpdatedBy!=null?hotel.UpdatedBy:null;
                _tbl.UpdatedDate=hotel.UpdatedDate!=null?hotel.UpdatedDate:DateTime.Now;
                _tbl.IconImage=hotel.IconImage!=null?hotel.IconImage:_tbl.IconImage;
                _tbl.BannerImage=hotel.BannerImage!=null?hotel.BannerImage:_tbl.BannerImage;
                await _context.SaveChangesAsync();
            
            }
            return _tbl;

        }
    }
}
