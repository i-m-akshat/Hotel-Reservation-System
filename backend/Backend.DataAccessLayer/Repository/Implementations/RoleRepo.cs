using Backend.DataAccessLayer.Context.DBContext;
using Backend.DataAccessLayer.Context.Models;
using Backend.DataAccessLayer.Repository.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace Backend.DataAccessLayer.Repository.Implementations
{
    public class RoleRepo : IRoleRepo
    {
        private readonly BaseraHotelReservationSystemContext _context;
        public RoleRepo(BaseraHotelReservationSystemContext context)  {
        _context= context;  
        }
        public async Task<TblRole> Create(TblRole _role)
        {
            try
            {
               await _context.TblRoles.AddAsync(_role);
                await _context.SaveChangesAsync();
                return _role;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<TblRole> Delete(long id)
        {
            try
            {
                var tbl=await _context.TblRoles.FindAsync(id);
                tbl.IsActive = false;
                await _context.SaveChangesAsync();
                return tbl;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<List<TblRole>> GetAll()
        {
            return await _context.TblRoles.ToListAsync();
        }

        public async Task<TblRole> GetByID(long id)
        {
            return await _context.TblRoles.FindAsync(id);
        }

        public async Task<TblRole> Update(TblRole _role, long id)
        {
           var tbl= await _context.TblRoles.FindAsync(id);
            if (tbl != null) {
                tbl.Role = _role.Role;
            }
            await _context.SaveChangesAsync();
            return tbl;
        }
    }
}
