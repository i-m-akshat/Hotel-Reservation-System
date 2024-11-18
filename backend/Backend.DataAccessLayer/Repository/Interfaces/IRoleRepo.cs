using Backend.DataAccessLayer.Context.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.DataAccessLayer.Repository.Interfaces
{
    public interface IRoleRepo
    {
        /// <summary>
        /// Get the role by their id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TblRole> GetByID(long id);
        /// <summary>
        /// Get All the roles
        /// </summary>
        /// <returns></returns>
        Task<List<TblRole>> GetAll();
        /// <summary>
        /// To Create the new roles 
        /// </summary>
        /// <param name="_role"></param>
        /// <returns></returns>
        Task<TblRole> Create(TblRole _role);
        /// <summary>
        /// To update the roles
        /// </summary>
        /// <param name="_role"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TblRole> Update(TblRole _role, long id);
        /// <summary>
        /// To delete the roles 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TblRole> Delete(long id);

      
    }
}
