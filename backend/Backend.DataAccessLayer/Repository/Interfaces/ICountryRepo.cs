using Backend.DataAccessLayer.Context.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.DataAccessLayer.Repository.Interfaces
{
    public interface ICountryRepo
    {

        /// <summary>
        /// To get all the countries
        /// </summary>
        /// <returns></returns>
        Task<List<TblCountry>> GetAll();
        /// <summary>
        /// To get the country based on the id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TblCountry> Get(long id);
        /// <summary>
        /// to create the country
        /// </summary>
        /// <param name="country"></param>
        /// <returns></returns>
        Task<TblCountry> Create(TblCountry country);
        /// <summary>
        /// to update the country based on the provided id 
        /// </summary>
        /// <param name="country"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TblCountry>  Update(TblCountry country,long id);
        /// <summary>
        /// To delete the country based on the provided id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TblCountry> Delete(long id);    
    }
}
