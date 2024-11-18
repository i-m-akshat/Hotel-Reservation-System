using Frontend.Logic.Interfaces;
using Frontend.Logic.Utility;
using Frontend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.Logic.Implementations
{
    public class RoleDao : IRoleDAO
    {
        private readonly IRestUtility<string> _hitman =new RestUtility<string>();
        private readonly ISecureDAO secureDAO = new SecureDao();
        private readonly string BaseUrl = "https://localhost:6969/api/Role/";
        public async Task<string> Create(string _Role)
        {
            try
            {
                var res = await _hitman.PostAsync(BaseUrl, "Create", _Role);
                return res;

            }
            catch (Exception ex) 
            {

                throw;
            }
        }

        public async Task<string> Delete(string id)
        {
            var res = await _hitman.DeleteAsync(BaseUrl, "Delete", id);
            return res;
        }

        public async Task<string> getAll()
        {
            var res =await _hitman.GetAsync(BaseUrl, "");
            return res;
        }

        public async Task<string> GetById(string id)
        {
            var res=await _hitman.GetByIDAsync(BaseUrl,"Get", id);
            return res;
        }

        public async Task<string> Update(string _Role, string id)
        {
            var res = await _hitman.PutAsync(BaseUrl, "Update", id,_Role);
            return res;
        }
    }
}
