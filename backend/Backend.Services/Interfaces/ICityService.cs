using Backend.Models.City_Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Services.Interfaces
{
    public interface ICityService
    {

        /// <summary>
        /// To Get all the cities 
        /// </summary>
        /// <returns></returns>
        Task<List<City_Model>> Get();
        /// <summary>
        /// To Get the city by id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<City_Model> GetById(long id);
        Task<City_Model> Create(City_Model city);
       Task<City_Model> Update(City_Model city, long id);
        Task<City_Model> Delete(long id);
    }
}
