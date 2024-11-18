
using Frontend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.Logic.Interfaces
{
    public interface IRoleDAO
    {
        /// <summary>
        /// to create the role
        /// </summary>
        /// <param name="_Role"></param>
        /// <returns></returns>
        Task<string> Create(string _Role);
        /// <summary>
        /// to update the role
        /// </summary>
        /// <param name="_Role"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<string> Update(string _Role, string id);
        /// <summary>
        /// to delete the role
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<string> Delete(string id);
        /// <summary>
        /// To get all the roles
        /// </summary>
        /// <returns></returns>
        Task<string> getAll();
        /// <summary>
        /// To get the string by their id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<string> GetById(string id);
    }
}
