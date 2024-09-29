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
        List<TblCountry> GetAll();
        TblCountry Get(int id);
        void Create(TblCountry country);
        void Update(TblCountry country);
        void Delete(int id);    
    }
}
