using Backend.DataAccessLayer.Context.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.DataAccessLayer.Repository.Interfaces
{
    public interface IStateRepo
    {
        Task<List<TblState>> GetAll();
        Task<TblState> Get(int id);
        Task<TblState> Create(TblState tblState);
        Task<TblState> Update(TblState tblState);
        Task<TblState> Delete(int id);
    }
}
