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
        List<TblCity> GetAll();
        /// <summary>
        /// to get the city by provided id 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TblCity Get(int id);
        /// <summary>
        /// To create the city 
        /// </summary>
        /// <param name="city"></param>
        void Create(TblCity city);
        /// <summary>
        /// To update the city based on the id 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="city"></param>
        void Update(long id ,TblCity city);
        /// <summary>
        /// To delete the city based on the id 
        /// </summary>
        /// <param name="id"></param>
        void Delete(int id);
    }
}
