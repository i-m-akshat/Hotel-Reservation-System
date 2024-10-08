using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.Logic.Interfaces
{
    public interface IStateDAO
    {
        /// <summary>
        /// Gets all the states
        /// </summary>
        /// <returns></returns>
        Task<string> GetAll();
        /// <summary>
        /// Gets the state by id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<string> GetByid(string id);
        /// <summary>
        /// Create/Add the State 
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        Task<string> Create(string state);
        /// <summary>
        /// Update the state based on the provided id 
        /// </summary>
        /// <param name="state"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<string> update(string state, string id);
        /// <summary>
        /// To Delete the state based on provided id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<string> Delete(string id);
    }
}
