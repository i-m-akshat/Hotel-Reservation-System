using Frontend.Logic.Interfaces;
using Frontend.Logic.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.Logic.Implementations
{
    public class StateDao : IStateDAO
    {
        private readonly ISecureDAO secureDAO = new SecureDao();
        private readonly string BaseUrl = "https://localhost:6969/api/State/";
        private static readonly IRestUtility<string> _hitman= new RestUtility<string>();    

        public async Task<string> Create(string state)
        {
            var res =await _hitman.PostAsync(BaseUrl, "Create", state);
            if (res != null)
            {
                return res;
            }
            else
            {
                return null;
            }
        }

        public async Task<string> Delete(string id)
        {
            var res =await _hitman.DeleteAsync(BaseUrl, "Delete", id);
            if (res != null)
            {
                return res;
            }
            else
            {
                return null;
            }
        }

        public async Task<string> GetAll()
        {
            var res=await _hitman.GetAsync(BaseUrl, "GetAll");
            //using (var httpClient = new HttpClient())
            //{
            //    httpClient.BaseAddress = new Uri(BaseUrl);
            //    var requestUrl = "GetAll";
            //    httpClient.Timeout = TimeSpan.FromMinutes(10);

            //    StringContent content = new StringContent("", Encoding.UTF8, "application/json");
            //    HttpResponseMessage httpResponse = httpClient.GetAsync(requestUrl).Result;
            //    if (httpResponse != null)
            //    {
            //        var res = httpResponse.Content.ReadAsStringAsync().Result;
            //        return res;
            //    }
            //    else
            //    {
            //        return null;
            //    }
            //}
            if (res != null)
            {
                return res;
            }
            else
            {
                return null;
            }
        }

        public async Task<string> GetByid(string id)
        {
            var res=await _hitman.GetByIDAsync(BaseUrl,"Get",id);
            if (res != null)
            {
                return res;
            }
            else
            {
                return null;
            }
        }

        public async Task<string> update(string state, string id)
        {
            var res = await _hitman.PutAsync(BaseUrl, "Update",id,state);
            if (res != null)
            {
                return res;
            }
            else
            {
                return null;
            }
        }
    }
}
