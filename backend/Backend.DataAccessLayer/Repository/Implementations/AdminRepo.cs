using Backend.DataAccessLayer.Context.DBContext;
using Backend.DataAccessLayer.Context.Models;
using Backend.DataAccessLayer.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Backend.DataAccessLayer.Repository.Implementations
{
    public class AdminRepo : IAdminRepo
    {
        private  readonly BaseraHotelReservationSystemContext _context;
        private readonly char[] characters = {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm',
    'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'};
        public AdminRepo(BaseraHotelReservationSystemContext context)
        {
            _context = context; 
        }
        public async Task<TblAdmin> Create(TblAdmin tblAdmin)
        {
            if (tblAdmin != null)
            {
                tblAdmin.Isactive = true;
                tblAdmin.Password = GenPwd(tblAdmin.FullName, tblAdmin.PhoneNumber);
            }
            await _context.TblAdmins.AddAsync(tblAdmin);
            await _context.SaveChangesAsync();
            return tblAdmin;
        }
        /// <summary>
        /// To generate random password
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private string GenPwd(string FullName,string mobileNo)
        {
            string[] _arrName = FullName.Split(" ");
            string first=_arrName[0].Substring(0, 2);
            string second = _arrName[1].Substring(0, 2);
            string trimmedMobile = mobileNo.Substring(0, 5);
            string finalPass = first + second + "@" + trimmedMobile;
            return finalPass;
        }
        public async Task<TblAdmin> Delete(long id)
        {
            var admin=await _context.TblAdmins.FindAsync(id);
            admin.Isactive = false;
            _context.TblAdmins.Update(admin);
            await _context.SaveChangesAsync();
            return admin;
        }

        public async Task<List<TblAdmin>> GetAll()
        {
           return await _context.TblAdmins.Where(x=>x.Isactive==true).Include(x => x.City).Include(x => x.State).Include(x=>x.Country).ToListAsync();
        }

        public async Task<TblAdmin> GetById(long id)
        {
           return await _context.TblAdmins.Include(x => x.Country).Include(x => x.City).Include(x => x.State).Where(x=>x.AdminId==id).FirstOrDefaultAsync();
        }

        public async Task<TblAdmin> GetByUserName(string username)
        {
            return await _context.TblAdmins.Where(x=>x.Adminname==username).FirstOrDefaultAsync();
        }

        public async Task<TblAdmin> Update(long id,TblAdmin tblAdmin)
        {
            var tbl_Admin = await _context.TblAdmins.FindAsync(id);
            if (tbl_Admin != null)
            {
                //tbl_Admin.AdminId=tblAdmin.AdminId!=null
                //    ?tblAdmin.AdminId : tbl_Admin.AdminId;
                tbl_Admin.Address=tblAdmin.Address!=null?tblAdmin.Address.ToString() : tblAdmin.Address;
                tbl_Admin.PhoneNumber=tblAdmin.PhoneNumber!=null?tblAdmin.PhoneNumber:tbl_Admin.PhoneNumber;
                tbl_Admin.UpdatedBy=tblAdmin.UpdatedBy!=null?tblAdmin.UpdatedBy
                    :tbl_Admin.UpdatedBy;
                tbl_Admin.UpdatedDate = DateTime.Now;
                tbl_Admin.Adminname = tblAdmin.Adminname != null ? tblAdmin.Adminname : tbl_Admin.Adminname;
                tbl_Admin.FullName=tblAdmin.FullName!=null?tblAdmin.FullName : tbl_Admin.FullName;
                tbl_Admin.CityId=tblAdmin.CityId!=null?tblAdmin.CityId:tbl_Admin.CityId;
                tbl_Admin.StateId=tblAdmin.StateId!=null?tblAdmin.StateId:tbl_Admin.StateId;
                tbl_Admin.CountryId=tblAdmin.CountryId!=null?tblAdmin.CountryId:tbl_Admin.CountryId;
                tbl_Admin.EmailId=tblAdmin.EmailId!=null?tblAdmin.EmailId:tbl_Admin.EmailId;
                tbl_Admin.Password=tblAdmin.Password!=null?tblAdmin.Password:tbl_Admin.Password;
            }
             //_context.TblAdmins.Update(tblAdmin);
            await _context.SaveChangesAsync();
            return tblAdmin;
        }
    }
}
