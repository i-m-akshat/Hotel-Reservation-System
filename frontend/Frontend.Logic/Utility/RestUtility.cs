using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Frontend.Logic.Utility
{
    public class RestUtility<T> : IRestUtility<T>
    {
        public async Task<T> DeleteAsync(string BaseUrl, string RequestUrl, string id)
        {
            using(var httpClient=new HttpClient())
            {
                httpClient.BaseAddress = new Uri(BaseUrl);
                id = WebUtility.UrlEncode(id);
                var requestUrl = RequestUrl + "?id=" + id;
                StringContent  content = new StringContent("", Encoding.UTF8, "application/json");
              HttpResponseMessage response= httpClient.DeleteAsync(requestUrl).Result;
                if (response.IsSuccessStatusCode)
                {
                    var res= await response.Content.ReadAsStringAsync();
                    if (typeof(T) == typeof(string))
                    {
                        return (T)(object)res; //This is necessary because generics don't allow direct casting to an unknown type T.
                    }
                    else
                    {
                        T obj=JsonConvert.DeserializeObject<T>(res);    
                        return obj;
                    }
                }
                else
                {
                    throw new Exception($"Error:{response.StatusCode}-Reason:{response.ReasonPhrase}");
                }
            }
        }

        public async Task<T> GetAsync(string BaseUrl, string RequestUrl)
        {
            using(var httpClient=new HttpClient())
            {
                httpClient.BaseAddress=new Uri(BaseUrl);
                var requestURL=RequestUrl;
                StringContent content=new StringContent("", Encoding.UTF8, "application/json");
                HttpResponseMessage response=httpClient.GetAsync(requestURL).Result;
                if (response.IsSuccessStatusCode)
                {
                    var res=await response.Content.ReadAsStringAsync(); 
                    if(typeof(T) == typeof(string))
                    {
                        return (T)(object)(res);
                    }
                    else
                    {
                        T obj = JsonConvert.DeserializeObject<T>(res);
                        return (T)(obj);
                    }
                }
                else
                {
                    throw new Exception($"Error:{response.StatusCode}-result:{response.ReasonPhrase}");
                }

            }
        }

        public async Task<T> GetByIDAsync(string BaseUrl, string RequestUrl, string id)
        {
            using(var httpClient=new HttpClient())
            {
                httpClient.BaseAddress = new Uri(BaseUrl);
                //id=WebUtility.UrlEncode(id);
                id = HttpUtility.UrlEncode(id);
                var requestURL = RequestUrl+"?id="+id;
                StringContent content = new StringContent("", Encoding.UTF8, "application/json");
                HttpResponseMessage response = httpClient.GetAsync(requestURL).Result;
                if (response.IsSuccessStatusCode)
                {
                    var res = await response.Content.ReadAsStringAsync();
                    if (typeof(T) == typeof(string))
                    {
                        return (T)(object)(res);
                    }
                    else
                    {
                        T obj = JsonConvert.DeserializeObject<T>(res);
                        return (T)(obj);
                    }
                }
                else
                {
                    throw new Exception($"Error:{response.StatusCode}-result:{response.ReasonPhrase}");
                }
            }
        }

        public  async Task<T> PostAsync(string BaseUrl, string RequestUrl, string Content)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(BaseUrl);
                var requestUrl = RequestUrl ;
                Content = JsonConvert.SerializeObject(Content);
                StringContent _content = new StringContent(Content, Encoding.UTF8, "application/json");
                HttpResponseMessage response = httpClient.PostAsync(requestUrl, _content).Result;
                if (response != null)
                {
                    var res = await response.Content.ReadAsStringAsync();
                    if (typeof(T) == typeof(string))
                    {
                        return (T)(object)res;
                    }
                    else
                    {
                        T obj = JsonConvert.DeserializeObject<T>(res);
                        return obj;
                    }

                }
                else
                {
                    throw new Exception($"Error:{response.StatusCode}-{response.ReasonPhrase}");
                }
            }
        }

        public async Task<T> PutAsync(string BaseUrl, string RequestUrl, string id, string Content)
        {
            using(var httpClient=new HttpClient())
            {
                httpClient.BaseAddress = new Uri(BaseUrl);
                id = WebUtility.UrlEncode(id);
                var requestUrl=RequestUrl+ "?id=" + id;
                Content = JsonConvert.SerializeObject(Content);
                StringContent _content=new StringContent(Content, Encoding.UTF8,"application/json");
                HttpResponseMessage response= httpClient.PutAsync(requestUrl,_content).Result;
                if (response != null)
                {
                    var res= await response.Content.ReadAsStringAsync();
                    if (typeof(T)==typeof(string))
                    {
                        return (T)(object)res;
                    }else 
                    {
                        T obj=JsonConvert.DeserializeObject<T>(res);
                        return obj;
                    }
                    
                }
                else
                {
                    throw new Exception($"Error:{response.StatusCode}-{response.ReasonPhrase}") ;
                }
            }
        }
    }
}
