
using Backend.Models.Admin_Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Services.Interfaces
{
    public interface IAdminService
    {
        /// <summary>
        /// To get the admin by username
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        Task<Admin> GetByUserName(string username);
        /// <summary>
        /// To get all the admins 
        /// </summary>
        /// <returns></returns>
        Task<List<Admin>> GetAll();
        /// <summary>
        /// To create the admin 
        /// </summary>
        /// <param name="Admin"></param>
        /// <returns></returns>
        Task<Admin> Create(Admin Admin);
        /// <summary>
        /// To update the admin by id 
        /// </summary>
        /// <param name="Admin"></param>
        /// <returns></returns>
        Task<Admin> Update(Admin Admin, long id);
        /// <summary>
        /// To delete the admin based on the provided id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Admin> Delete(int id);
    }
}
