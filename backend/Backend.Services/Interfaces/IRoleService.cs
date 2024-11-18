using Backend.Models.Admin_Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Services.Interfaces
{
    public interface IRoleService
    {
        /// <summary>
        /// to create the role
        /// </summary>
        /// <param name="_Role"></param>
        /// <returns></returns>
        Task<Role> Create(Role _Role);
        /// <summary>
        /// to update the role
        /// </summary>
        /// <param name="_Role"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Role> Update(Role _Role,long id);
        /// <summary>
        /// to delete the role
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Role> Delete(long id);
        /// <summary>
        /// To get all the roles
        /// </summary>
        /// <returns></returns>
        Task<List<Role>> getAll();
        /// <summary>
        /// To get the role by their id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Role> GetById(long id);    
    }
}
