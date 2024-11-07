using Frontend.Logic.Interfaces;
using Frontend.Logic.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.Logic.Implementations
{
    public class CityDao : ICityDao
    {
        private readonly ISecureDAO secureDAO = new SecureDao();
        private readonly IRestUtility<string> _hitman = new RestUtility<string>();
        private readonly string BaseUrl = "https://localhost:6969/api/City/";
        public async Task<string> Create(string City)
        {
            return await _hitman.PostAsync(BaseUrl, "Create", City);
        }

        public async Task<string> Delete(string id)
        {
            return await _hitman.DeleteAsync(BaseUrl, "Delete", id);
        }

        public async Task<string> Get()
        {
            return await _hitman.GetAsync(BaseUrl, "");
        }

        public async Task<string> GetByID(string id)
        {
            return await _hitman.GetByIDAsync(BaseUrl, "Get",id);

        }

        public async Task<string> Update(string City, string id)
        {
            return await _hitman.PutAsync(BaseUrl, "Update",id,City);
        }
    }
}
