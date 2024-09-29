using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Backend.DataAccessLayer.Context.Models;
using System.Threading.Tasks;

namespace Backend.Infrastructure.Repository.Interfaces
{
    public interface IUserRepo
    {
         Task<List<TblUser>> GetAll();
        Task<TblUser> CreateUser(TblUser user);
        Task<TblUser> GetUserByUsername(string username);   
    }
}
