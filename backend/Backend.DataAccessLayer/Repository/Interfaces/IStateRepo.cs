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
        List<TblState> GetAll();
        TblState Get(int id);
        void Create(TblState tblState);
        void Update(TblState tblState);
        void Delete(int id);
    }
}
