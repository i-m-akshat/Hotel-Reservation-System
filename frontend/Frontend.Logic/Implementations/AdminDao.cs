using Frontend.Logic.Interfaces;
using Frontend.Logic.Utility;
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
        private readonly static IRestUtility<string> _hitman=new RestUtility<string>(); 

        public async Task<string> Create(string Admin)
        {
            try
            {
                var res = await _hitman.PostAsync(BaseUrl, "Create", Admin);
                return res; 
                
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<string> Delete(string id)
        {
            try
            {
                var res = await _hitman.DeleteAsync(BaseUrl, "Delete", id);
                return res;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<string> Get(string id)
        {
            try
            {
                var res = await _hitman.GetByIDAsync(BaseUrl, "Get", id);
                return res;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<string> GetAll()
        {
            try
            {
                var res = await _hitman.GetAsync(BaseUrl, "");
                return res;
            }
            catch (Exception)
            {

                throw;
            }
        }

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

        public async Task<string> Update(string Admin, string id)
        {
            var res=await _hitman.PutAsync(BaseUrl, "Update",id, Admin);
            return res;
        }
    }
}
