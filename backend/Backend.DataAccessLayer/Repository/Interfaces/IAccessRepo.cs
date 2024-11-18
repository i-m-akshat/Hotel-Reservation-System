using Backend.DataAccessLayer.Context.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.DataAccessLayer.Repository.Interfaces
{
   public interface IAccessRepo
    {
        /// <summary>
        /// .To get all access
        /// </summary>
        /// <returns></returns>
        Task<List<TblAccess>> Get();
        /// <summary>
        /// To get access by id
        /// </summary>
        /// /// <param name="id"></param>
        /// <returns></returns>
        Task<TblAccess> GetByID(long id);
        /// <summary>
        /// To create the access
        /// </summary>
        /// <param name="_access"></param>
        /// <returns></returns>
        Task<TblAccess> Create(TblAccess _access);
        /// <summary>
        /// To update the access
        /// </summary>
        /// <param name="_access"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TblAccess> Update(TblAccess _access, long id);
        /// <summary>
        /// To delete the access
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TblAccess> Delete(long id);
    }
}
