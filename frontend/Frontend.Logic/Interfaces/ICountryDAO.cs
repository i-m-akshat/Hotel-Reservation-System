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
    }
}
