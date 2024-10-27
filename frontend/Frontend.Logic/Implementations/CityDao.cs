using Frontend.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.Logic.Implementations
{
    public class CityDao : ICityDao
    {
        public Task<string> Create(string City)
        {
            throw new NotImplementedException();
        }

        public Task<string> Delete(string id)
        {
            throw new NotImplementedException();
        }

        public Task<string> Get()
        {
            throw new NotImplementedException();
        }

        public Task<string> GetByID(string id)
        {
            throw new NotImplementedException();
        }

        public Task<string> Update(string City, string id)
        {
            throw new NotImplementedException();
        }
    }
}
