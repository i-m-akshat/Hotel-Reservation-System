using Frontend.Logic.Interfaces;
using Frontend.Logic.Utility;
using Frontend.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.Logic.Implementations
{
    public class CountryDao : ICountryDAO
    {
        private readonly ISecureDAO secureDAO=new SecureDao();
        private readonly IRestUtility<string> _hitman=new RestUtility<string>();
        private readonly string BaseUrl = "https://localhost:6969/api/Country/";
        public async Task<string> Create(string _country)
        {
            try
            {
                //using (var httpClient = new HttpClient()) { 
                //httpClient.BaseAddress = new Uri(BaseUrl);
                //    var requestUrl = "Create";
                //    httpClient.Timeout = TimeSpan.FromMinutes(10);
                //    string country = JsonConvert.SerializeObject(_country);
                //    StringContent content = new StringContent(country, Encoding.UTF8, "application/json");
                //    HttpResponseMessage httpResponse =httpClient.PostAsync(requestUrl,content).Result;
                //    if (httpResponse != null) { 
                //    var res= httpResponse.Content.ReadAsStringAsync().Result;
                //        return res;
                //    }
                //    else
                //    {
                //        return null;
                //    }
                //}
                return await _hitman.PostAsync(BaseUrl,"Create",_country);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<string> Delete(string id)
        {
            //using(var httpClient= new HttpClient())
            //{
            //    httpClient.BaseAddress = new Uri(BaseUrl);
            //    var requestUrl = "Delete/" + id;
            //    StringContent content=new StringContent("", Encoding.UTF8, "application/json");
            //    HttpResponseMessage res=await httpClient.DeleteAsync(requestUrl);
            //    if (res != null)
            //    {
            //        var res_ret = await res.Content.ReadAsStringAsync();
            //        return res_ret;
            //    }
            //    else
            //        return null;
            //}
            return await _hitman.DeleteAsync(BaseUrl, "Delete", id);
        }

        public async Task<string> GetAll()
        {
            //using (var httpClient = new HttpClient())
            //{
            //    httpClient.BaseAddress = new Uri(BaseUrl);
            //    var requestUrl = "";
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
            return await _hitman.GetAsync(BaseUrl, "");
        }

        public async Task<string> Update(string id, string _country)
        {
            return await _hitman.PutAsync(BaseUrl,"Update",id, _country);
           //using(var httpClient=new HttpClient())
           // {
           //     httpClient.BaseAddress = new Uri(BaseUrl);
           //     var requestUrl = "Update/" + id;
           //     StringContent content = new StringContent(JsonConvert.SerializeObject(_country), Encoding.UTF8, "application/json");
           //     HttpResponseMessage httpResponse=httpClient.PutAsync(requestUrl,content).Result;
           //     if (httpResponse != null)
           //     {
           //         var res=await httpResponse.Content.ReadAsStringAsync();
           //         return res;
           //     }
           //     else
           //     {
           //         return null ;
           //     }
           // }
        }
        public async Task<string> GetById(string id)
        {
            //using (var httpClient = new HttpClient())
            //{
            //    httpClient.BaseAddress = new Uri(BaseUrl);
            //    var requestUrl = "Get?id="+id;
            //    //StringContent content = new StringContent(_country, Encoding.UTF8, "application/json");
            //    HttpResponseMessage httpResponse = httpClient.GetAsync(requestUrl).Result;
            //    if (httpResponse != null)
            //    {
            //        var res = await httpResponse.Content.ReadAsStringAsync();
            //        return res;
            //    }
            //    else
            //    {
            //        return null;
            //    }
            //}

            return await _hitman.GetByIDAsync(BaseUrl,"Get", id);
        }
    }
}
