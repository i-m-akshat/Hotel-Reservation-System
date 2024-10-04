using Frontend.Logic.Interfaces;
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
        public async Task<string> GetAll()
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(BaseUrl);
                var requestUrl = "GetAll";
                httpClient.Timeout = TimeSpan.FromMinutes(10);

                StringContent content = new StringContent("", Encoding.UTF8, "application/json");
                HttpResponseMessage httpResponse = httpClient.GetAsync(requestUrl).Result;
                if (httpResponse != null)
                {
                    var res = httpResponse.Content.ReadAsStringAsync().Result;
                    return res;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
