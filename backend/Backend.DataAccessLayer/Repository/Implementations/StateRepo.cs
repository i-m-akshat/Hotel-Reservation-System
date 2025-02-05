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
    public class StateRepo : IStateRepo
    {
        private readonly BaseraHotelReservationSystemContext _context;
        public StateRepo(BaseraHotelReservationSystemContext context)
        {
            _context = context;
        }
        public async Task<TblState> Create(TblState tblState)
        {
            tblState.IsActive= true;    
            await _context.TblStates.AddAsync(tblState);
            await _context.SaveChangesAsync();
            return tblState;
        }

        public async Task<TblState> Delete(long id)
        {
            var tblState = await _context.TblStates.FindAsync(id);
            tblState.IsActive = false;
            //_context.TblStates.Remove(tblState);
            await _context.SaveChangesAsync() ; return tblState;
        }

        public async Task<TblState> Get(long id)
        {
            return await _context.TblStates.Include(x => x.Country).Where(x=>x.StateId==id).FirstOrDefaultAsync();
        }

        public async Task<List<TblState>> GetAll()
        {
            return await  _context.TblStates.Include(x=>x.Country).Where(x=>x.IsActive==true).ToListAsync();
        }
        //here i have commented out the update part because it was updating and adding the same row at the same time 
        public async Task<TblState> Update(TblState tblState, long id)
        {
            var tbl_State = await _context.TblStates.FindAsync(id);
            //if (tbl_State != null) { 
            //    tbl_State.StateName=tblState.StateName!=null?tblState.StateName:tbl_State.StateName;
            //    tbl_State.CountryId=tblState.CountryId!=null?tblState.CountryId.Value:tbl_State.CountryId;
            //    _context.TblStates.Update(tblState);
            //    await _context.SaveChangesAsync(); return tbl_State;
            //}
            if (tbl_State != null)
            {
                
                tbl_State.StateName = tblState.StateName ?? tbl_State.StateName; 
                tbl_State.CountryId = tblState.CountryId != 0 ? tblState.CountryId : tbl_State.CountryId; 

               
                await _context.SaveChangesAsync();
                return tbl_State; 
            }
            else
            {
                return null;
            }
            
            

        }
    }
    
}
