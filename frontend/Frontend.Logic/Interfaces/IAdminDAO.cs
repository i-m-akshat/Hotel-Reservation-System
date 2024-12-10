using Frontend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.Logic

{
    public interface IAdminDAO
    {
        /// <summary>
        /// Login functionality
        /// </summary>
        /// <param name="Username"></param>
        /// <returns></returns>
        Task<string> Login(string Username);
        /// <summary>
        /// To create or add the admin
        /// </summary>
        /// <param name="Admin"></param>
        /// <returns></returns>
        Task<string> Create(string Admin);
        /// <summary>
        /// to update the admin 
        /// </summary>
        /// <param name="Admin"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<string> Update(string Admin,string id);
        /// <summary>
        /// to delete or deactivate the admin
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<string> Delete(string id);
        /// <summary>
        /// to get the admin by its id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<string > Get(string id);
        /// <summary>
        /// to get all the admins
        /// </summary>
        /// <returns></returns>
        Task<string> GetAll();

    }
}
