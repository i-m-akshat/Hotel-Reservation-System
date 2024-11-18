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
    public class AccessRepo : IAccessRepo
    {
        private readonly BaseraHotelReservationSystemContext _context;
        public AccessRepo(BaseraHotelReservationSystemContext context)
        {
            _context = context;
        }
        public async Task<TblAccess> Create(TblAccess _access)
        {
            await _context.TblAccesses.AddAsync(_access);
            await _context.SaveChangesAsync();
            return _access;
        }

        public async Task<TblAccess> Delete(long id)
        {
            var tbl=await _context.TblAccesses.FindAsync(id);
            if (tbl != null)
            {
                tbl.IsActive = false;   
            }
            await _context.SaveChangesAsync();
            return tbl;

        }

        public async Task<List<TblAccess>> Get()
        {
            return await _context.TblAccesses.ToListAsync();
        }

        public async Task<TblAccess> GetByID(long id)
        {
            return await _context.TblAccesses.FindAsync(id);
          
        }

        public async Task<TblAccess> Update(TblAccess _access, long id)
        {
            var tbl = await _context.TblAccesses.FindAsync(id);
            if (tbl != null) { 
            tbl.AccessUrl=_access.AccessUrl;
                tbl.AccessProvidedBy=_access.AccessProvidedBy;
                tbl.AccessProvidedDate=DateTime.Now;
                tbl.IconUrl=_access.IconUrl;    
                tbl.Name=_access.Name;
                tbl.RoleId = _access.RoleId;
                
            }
            await _context.SaveChangesAsync();
            return tbl;
        }
    }
}
