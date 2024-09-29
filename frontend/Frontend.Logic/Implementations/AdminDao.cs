using Frontend.Logic.Interfaces;
using Frontend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.Logic.Implementations
{
    public class AdminDao : IAdminDAO
    {
       
        private readonly string BaseUrl = "https://localhost:6969/api/Admin/";
        //public AdminDao(ISecureDAO secureDao)
        //{
        //    _secureDAO = secureDao;
        //}
        public  async Task<string> Login(string Username)
        {
            using(var httpClient=new HttpClient())
            {
                httpClient.BaseAddress = new Uri(BaseUrl);
                //httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
                httpClient.Timeout = TimeSpan.FromMinutes(10);
                StringContent content = new StringContent("", Encoding.UTF8, "application/json");
                var requestUrl = $"Login?username={Username}";
                HttpResponseMessage httpResponse =  httpClient.GetAsync(requestUrl).Result;
                if (httpResponse != null) { 
                    string responseData=await httpResponse.Content.ReadAsStringAsync();
                    return responseData;
                }
                else
                {
                    return null;
                }
            }
        }
    }
}
