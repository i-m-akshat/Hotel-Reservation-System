using Backend.Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Infrastructure.Repository.Implementations
{
    
    public class UserRepo:IUserRepo
    {
        private readonly BaseraHotelReservationSystemContext _context;
        public UserRepo(BaseraHotelReservationSystemContext context)
        {
                _context=context;
        }

        public async Task<List<TblUser>> GetAll()
        {
            try
            {
                return await _context.TblUsers.Include(x=>x.City).Include(x=>x.State).Include(x=>x.Country).ToListAsync();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public async Task<TblUser> CreateUser(TblUser user)
        {
             await _context.TblUsers.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
