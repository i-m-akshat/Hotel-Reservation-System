using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.Logic.Interfaces
{
    public interface ICityDao
    {
        Task<string> Create(string City);
        Task<string> Update(string City,string id);
        Task<string> Delete(string id);
        Task<string> Get();
        Task<string> GetByID(string id);
    }
}
