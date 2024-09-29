using Backend.DataAccessLayer.Context.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.DataAccessLayer.Repository.Interfaces
{
    public interface IAdminRepo
    {
        Task<TblAdmin> GetByUserName(string username);
        Task<List<TblAdmin>> GetAll();
        Task<TblAdmin> Create(TblAdmin tblAdmin);
        Task<TblAdmin> Update(TblAdmin tblAdmin);
        Task<TblAdmin> Delete(int id);
    }
}
