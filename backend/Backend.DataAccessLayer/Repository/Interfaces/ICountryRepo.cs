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
        Task<List<TblCountry>> GetAll();
        Task<TblCountry> Get(long id);
        Task<TblCountry> Create(TblCountry country);
        Task<TblCountry>  Update(TblCountry country,long id);
        Task<TblCountry> Delete(long id);    
    }
}
