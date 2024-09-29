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
        public AdminRepo(BaseraHotelReservationSystemContext context)
        {
            _context = context; 
        }
        public async Task<TblAdmin> Create(TblAdmin tblAdmin)
        {

            await _context.TblAdmins.AddAsync(tblAdmin);
            await _context.SaveChangesAsync();
            return tblAdmin;
        }

        public async Task<TblAdmin> Delete(int id)
        {
            var admin=await _context.TblAdmins.FindAsync(id);
            admin.Isactive = false;
            _context.TblAdmins.Update(admin);
            await _context.SaveChangesAsync();
            return admin;
        }

        public async Task<List<TblAdmin>> GetAll()
        {
           return await _context.TblAdmins.ToListAsync();
        }

        public async Task<TblAdmin> GetByUserName(string username)
        {
            return await _context.TblAdmins.Where(x=>x.Adminname==username).FirstOrDefaultAsync();
        }

        public async Task<TblAdmin> Update(TblAdmin tblAdmin)
        {
             _context.TblAdmins.Update(tblAdmin);
            await _context.SaveChangesAsync();
            return tblAdmin;
        }
    }
}
