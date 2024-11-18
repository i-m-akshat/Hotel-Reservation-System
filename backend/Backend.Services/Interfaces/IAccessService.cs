using Backend.Models.Admin_Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Services.Interfaces
{
    public interface IAccessService
    {
        /// <summary>
        /// To Create the access
        /// </summary>
        /// <param name="Data"></param>
        /// <returns></returns>
        Task<Access> Create(Access Data);
        /// <summary>
        /// To Udpate the access
        /// </summary>
        /// <param name="Data"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Access> Update(Access Data,long id);
        /// <summary>
        /// To delete the accesss
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Access> Delete(long id);
        /// <summary>
        /// To get the access by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Access> Get(long id);
        /// <summary>
        /// To get All the access
        /// </summary>
        /// <returns></returns>
        Task<List<Access>> GetAll();
    }
}
