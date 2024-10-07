using Frontend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.Logic.Interfaces
{
    public interface ICountryDAO
    {
        Task<string> GetAll();
        Task<string> Create(string _country);
        Task<string> Update(string id,string _country);
        Task<string> Delete(string id);
        Task<string> GetById(string id);
    }
}
