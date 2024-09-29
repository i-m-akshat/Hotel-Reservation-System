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
        List<TblCity> GetAll();

        TblCity Get(int id);
        void Create(TblCity city);
        void Update(TblCity city);
        void Delete(int id);
    }
}
