using Backend.DataAccessLayer.Context.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.DataAccessLayer.Repository.Interfaces
{
    public interface ICityRepo
    {
        /// <summary>
        /// To get all the cities
        /// </summary>
        /// <returns></returns>
        Task<List<TblCity>> GetAll();
        /// <summary>
        /// to get the city by provided id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TblCity> Get(long id);
        /// <summary>
        /// To create the city 
        /// </summary>
        /// <param name="city"></param>
        Task<TblCity> Create(TblCity city);
        /// <summary>
        /// To update the city based on the id 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="city"></param>
        Task<TblCity> Update(long id ,TblCity city);
        /// <summary>
        /// To delete the city based on the id 
        /// </summary>
        /// <param name="id"></param>
        Task<TblCity> Delete(long id);
        /// <summary>
        /// Get the cities based on stateid 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<List<TblCity>> GetCitiesBasedOnStateId(long id);
       
    }
}
