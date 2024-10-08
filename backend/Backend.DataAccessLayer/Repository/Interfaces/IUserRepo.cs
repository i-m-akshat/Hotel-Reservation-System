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
        /// <summary>
        /// To get all the users 
        /// </summary>
        /// <returns></returns>
        Task<List<TblUser>> GetAll();
        /// <summary>
        /// To Create the user
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        Task<TblUser> CreateUser(TblUser user);
        /// <summary>
        /// To get the user by username
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        Task<TblUser> GetUserByUsername(string username);
    }
}
