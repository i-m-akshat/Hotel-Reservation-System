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
        public class HotelImageDTO
        {
            public long HotelImageId { get; set; }

            public long? HotelId { get; set; }
            public string HotelName { get; set; }

            public string? ImageName { get; set; }

            public string? ContentType { get; set; }

            public bool? Isactive { get; set; }
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
                //var tbl = await _context.TblHotelimages.AsNoTracking().Select(x=>new TblHotelimage
                //{
                //    ContentType=x.ContentType,
                //    HotelId=x.HotelId,
                //    //Image=x.Image,
                //    ImageName=x.ImageName,
                //    Isactive=x.Isactive,
                //    Hotel=x.Hotel,


                //}).Where(x => x.Isactive == true).ToListAsync();
                //var tbl = await _context.TblHotelimages.FromSqlInterpolated($"select * from ActiveHotelImages").AsNoTracking()
                //    .ToListAsync();
                //var tbl = await _context.TblHotelimages.FromSqlInterpolated($"select * from ActiveHotelImages").Include(x=>x.Hotel).AsNoTracking().ToListAsync();
                //var tbl = await _context.Set<HotelImage>().FromSqlRaw(@"select * from ActiveHotelImages").ToListAsync();
                //var tbl_final = tbl.Select(x=>new TblHotelimage
                //{
                //    HotelId = x.HotelId,
                //    Hotel =
                //{
                //    HotelId = x.HotelId.Value,
                //    HotelName = x.HotelName,
                //},
                //    HotelImageId = x.HotelImageId,
                //    ContentType = x.ContentType,

                //    Isactive = x.Isactive,
                //    ImageName = x.ImageName,
                //}).ToList();
                //if (tbl_final != null)
                //{
                //    return tbl_final;
                //}
                //else
                //    return null;
                
                var tbl = await _context.Database
                    .SqlQueryRaw<HotelImageDTO>(@"SELECT 
                     a.hotel_image_id AS HotelImageId, 
                     a.hotel_id AS HotelId, 
                     a.image_name AS ImageName, 
                     a.content_type AS ContentType, 
                     a.isactive AS Isactive, 
                     b.HotelName AS HotelName
                 FROM 
                     ActiveHotelImages a 
                 INNER JOIN 
                     Basera_HotelReservationSystem..tbl_Hotel b ON a.hotel_id = b.HotelID")
                    .ToListAsync();

               
                var tbl_final = tbl.Select(x => new TblHotelimage
                {
                    HotelId = x.HotelId,
                    Hotel = new TblHotel
                    {
                        HotelId = x.HotelId.Value,
                        HotelName = x.HotelName,
                    },
                    HotelImageId = x.HotelImageId,
                    ContentType = x.ContentType,
                    Isactive = x.Isactive,
                    ImageName = x.ImageName,
                }).ToList();
                //.Skip(count).Take(5).ToList()
                //int pageSize = 5;
                if (tbl_final.Any()) 
                {
                    //int totalCount=tbl_final.Count();
                    //var totalPages = Convert.ToInt32(Math.Ceiling((double)(totalCount / pageSize)));
                    //return tbl_final.OrderBy(x => x.HotelImageId).Skip((count - 1) * pageSize).Take(pageSize).ToList();
                    return tbl_final;
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

        public async Task<TblHotelimage> GetImageById(long id)
        {
            try
            {
                var tbl = await _context.TblHotelimages.Where(x => x.HotelImageId == id).Include(x=>x.Hotel).FirstOrDefaultAsync();
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
