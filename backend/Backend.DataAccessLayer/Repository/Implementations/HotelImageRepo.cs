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
    public class HotelImageRepo : IHotelImageRepo
    {
        private static BaseraHotelReservationSystemContext _context;
        public HotelImageRepo(BaseraHotelReservationSystemContext context)
        {
            _context = context;
        }
        public async Task<TblHotelimage> AddHotelImage(TblHotelimage tblHotelImage)
        {
            try
            {
                tblHotelImage.Isactive = true;
                tblHotelImage.Createddate=DateTime.Now;
                await _context.TblHotelimages.AddAsync(tblHotelImage);
                await _context.SaveChangesAsync();
                return tblHotelImage;

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<TblHotelimage> DeleteHotelImage(long id)
        {
            try
            {
                var tbl = await _context.TblHotelimages.FindAsync(id);
                if (tbl != null)
                {
                    tbl.Isactive = false;
                    tbl.Deleteddate= DateTime.Now;  
                    await _context.SaveChangesAsync();
                    return tbl;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }

        public async Task<List<TblHotelimage>> GetAllImages()
        {
            try
            {
                var tbl = await _context.TblHotelimages.Include(x => x.Hotel).ToListAsync();
                if (tbl != null)
                {
                    return tbl;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<TblHotelimage> GetImageById(long id)
        {
            try
            {
                var tbl = await _context.TblHotelimages.Where(x => x.HotelImageId == id).FirstOrDefaultAsync();
                if (tbl != null)
                {
                    return tbl;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<List<TblHotelimage>> GetImages_HotelID(long Hotelid)
        {
            try
            {
                var tbl=await _context.TblHotelimages.Where(x=>x.HotelId==Hotelid).ToListAsync();
                if (tbl != null)
                {
                    return tbl;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<TblHotelimage> UpdateHotelImage(long id, TblHotelimage tblHotelImage)
        {
            try
            {
                var tbl = await _context.TblHotelimages.Where(x => x.HotelImageId == id).Include(x => x.Hotel).FirstOrDefaultAsync();
                if (tbl != null)
                {
                    tbl.Updateddate = DateTime.Now;
                    tbl.HotelId = tblHotelImage.HotelId != null ? tblHotelImage.HotelId : tbl.HotelId;
                    tbl.ImageName = tblHotelImage.ImageName != null ? tblHotelImage.ImageName : tbl.ImageName;
                    tbl.Image = tblHotelImage.Image != null ? tblHotelImage.Image : tbl.Image;
                    tbl.ContentType = tblHotelImage.ContentType != null ? tblHotelImage.ContentType : tbl.ContentType;
                    //tbl.Updatedby = tblHotelImage.Updatedby != null ? tblHotelImage.Updatedby : tbl.Updatedby;
                    await _context.SaveChangesAsync();
                    return tbl;
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
