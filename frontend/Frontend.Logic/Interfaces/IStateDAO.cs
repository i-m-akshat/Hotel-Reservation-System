using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.Logic.Interfaces
{
    public interface IStateDAO
    {
        Task<string> GetAll();
    }
}
