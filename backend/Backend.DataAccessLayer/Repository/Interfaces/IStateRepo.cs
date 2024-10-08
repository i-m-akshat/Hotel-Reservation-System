using Backend.DataAccessLayer.Context.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.DataAccessLayer.Repository.Interfaces
{
    public interface IStateRepo
    {

        /// <summary>
        /// To get all states
        /// </summary>
        /// <returns></returns>
        Task<List<TblState>> GetAll();
        /// <summary>
        /// To get the states based on the provided id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TblState> Get(long id);
        /// <summary>
        /// To create the state
        /// </summary>
        /// <param name="tblState"></param>
        /// <returns></returns>
        Task<TblState> Create(TblState tblState);
        /// <summary>
        /// To update the state based on provided id 
        /// </summary>
        /// <param name="tblState"></param>
        /// <returns></returns>
        Task<TblState> Update(TblState tblState, long id );
        /// <summary>
        /// To Delete the state based on the provided id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<TblState> Delete(long id);
    }
}
