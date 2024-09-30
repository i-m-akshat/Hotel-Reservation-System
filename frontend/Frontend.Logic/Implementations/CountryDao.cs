using Frontend.Logic.Interfaces;
using Frontend.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.Logic.Implementations
{
    public class CountryDao : ICountryDAO
    {
        private readonly ISecureDAO secureDAO=new SecureDao();
        private readonly string BaseUrl = "https://localhost:6969/api/Country/";
        public async Task<string> Create(string _country)
        {
            try
            {
                using (var httpClient = new HttpClient()) { 
                httpClient.BaseAddress = new Uri(BaseUrl);
                    var requestUrl = "Create";
                    httpClient.Timeout = TimeSpan.FromMinutes(10);
                    string country = JsonConvert.SerializeObject(_country);
                    StringContent content = new StringContent(country, Encoding.UTF8, "application/json");
                    HttpResponseMessage httpResponse =httpClient.PostAsync(requestUrl,content).Result;
                    if (httpResponse != null) { 
                    var res= httpResponse.Content.ReadAsStringAsync().Result;
                        return res;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<string> GetAll()
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(BaseUrl);
                var requestUrl = "Get";
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
