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
    public class HotelContactRepo : IHotelContactRepo
    {
        private static BaseraHotelReservationSystemContext _context;
        public HotelContactRepo(BaseraHotelReservationSystemContext context)
        {
            _context = context;
        }
        public async Task<TblHotelcontactdetail> CreateHotelContact(TblHotelcontactdetail hotelcontactdetail)
        {
            try
            {
                hotelcontactdetail.Createdby = null;
                await _context.TblHotelcontactdetails.AddAsync(hotelcontactdetail);
                await _context.SaveChangesAsync();
                return hotelcontactdetail;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<TblHotelcontactdetail> DeleteHotelContact(long id)
        {
            try
            {
                var hotelcontactDetails = await _context.TblHotelcontactdetails.FindAsync(id);
                if (hotelcontactDetails != null)
                {
                    hotelcontactDetails.Deletedby = null;
                    hotelcontactDetails.Isactive = false;
                    await _context.SaveChangesAsync();
                    return hotelcontactDetails;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<List<TblHotelcontactdetail>> GetAllHotels()
        {
            try
            {
                return await _context.TblHotelcontactdetails.Where(x=>x.Isactive==true).ToListAsync();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<List<TblHotelcontactdetail>> GetHotelContactDetailsByHotelId(long id)
        {
            try
            {
                var hotelcontactdetails = await _context.TblHotelcontactdetails.Where(x=>x.HotelId==id).ToListAsync();
                return hotelcontactdetails;

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<TblHotelcontactdetail> GetHotelContactsByid(long id)
        {
            try
            {
               var details= await _context.TblHotelcontactdetails.FindAsync(id);
                if (details != null)
                {
                    return details;
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

        public async Task<TblHotelcontactdetail> UpdateHotel(TblHotelcontactdetail hotelcontactdetail, long id)
        {
            try
            {
                var hotelcontactdetails=await _context.TblHotelcontactdetails.Where(x=>x.ContactId==id).FirstOrDefaultAsync();
                if (hotelcontactdetails != null)
                {

                    hotelcontactdetails.HotelId = hotelcontactdetail.HotelId != null ? hotelcontactdetail.HotelId : hotelcontactdetails.HotelId;
                    hotelcontactdetails.HotelContactType =hotelcontactdetail.HotelContactType!=null? hotelcontactdetail.HotelContactType: hotelcontactdetails.HotelContactType
                    hotelcontactdetails.HotelContactValue = hotelcontactdetail.HotelContactValue != null ? hotelcontactdetail.HotelContactValue : hotelcontactdetails.HotelContactValue;
                    hotelcontactdetails.Isprimary = hotelcontactdetail.Isprimary != null ? hotelcontactdetail.Isprimary : hotelcontactdetails.Isprimary;
                    hotelcontactdetails.Isactive           =hotelcontactdetail.Isactive!=null? hotelcontactdetail.Isactive : hotelcontactdetails.Isactive;
                    hotelcontactdetails.Createddate        =hotelcontactdetail.Createddate!=null? hotelcontactdetail.Createddate:   hotelcontactdetails.Createddate;
                    hotelcontactdetails.Createdby          =hotelcontactdetail.Createdby!=null? hotelcontactdetail.Createdby:   hotelcontactdetails.Createdby;
                    hotelcontactdetails.Updateddate        =hotelcontactdetail.Updateddate!=null?hotelcontactdetail.Updateddate: hotelcontactdetails.Updateddate;
                    hotelcontactdetails.Updatedby          =hotelcontactdetail.Updatedby!=null ? hotelcontactdetail.Updatedby: hotelcontactdetails.Updatedby;
                    hotelcontactdetails.Deleteddate        =hotelcontactdetail.Deleteddate!=null?hotelcontactdetail.Deleteddate:    hotelcontactdetails.Deleteddate;
                    hotelcontactdetails.Deletedby          =hotelcontactdetail.Deletedby!=null?hotelcontactdetail.Deletedby: hotelcontactdetails.Deletedby;
                    await _context.SaveChangesAsync();
                    return hotelcontactdetail;
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
