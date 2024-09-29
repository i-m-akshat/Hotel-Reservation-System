
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Frontend.LogicLayer.Interfaces;
using Frontend.Models;
using Newtonsoft.Json;


namespace Frontend.LogicLayer.Implementations
{
    public class UserDao : IUserDAO
    {
		//private readonly string BaseUrl = "https://localhost:7218/api/User/";
		//private readonly string BaseUrl = "https://localhost:5211/api/User/";
		//private readonly string BaseUrl = "https://localhost:6969/api/User/";
		private readonly string BaseUrl = "http://localhost:6969/api/User/";

		public async Task<string> GetUserByUserID(string Userid)
        {
            using(var httpClient=new HttpClient())
			{
				httpClient.BaseAddress = new Uri(BaseUrl);
				var requesturl =  $"GetByUserId?userid={Userid}";
				httpClient.Timeout = TimeSpan.FromMinutes(10);
                StringContent content = new StringContent( "",Encoding.UTF8, "application/json");
				HttpResponseMessage httpResponse = httpClient.GetAsync(requesturl).Result;
				if (httpResponse.IsSuccessStatusCode)
				{
					string responsedata=await httpResponse.Content.ReadAsStringAsync();
					return responsedata;
				}
				else
				{
					return null;
				}
            }
        }

        public async Task<string> Login(string Userid, string password)
        {
			try
			{
				using(var httpClient=new HttpClient())
				{
					httpClient.BaseAddress=new Uri(BaseUrl);
					var requestUrl = BaseUrl + "GetUser";
					httpClient.Timeout = TimeSpan.FromMinutes(15);
					var user = new User {
						UserId = Userid,
						Password = password
					};
					string json = JsonConvert.SerializeObject(user);
					StringContent httpContent=new StringContent(json, Encoding.UTF8, "application/json");
					HttpResponseMessage response = httpClient.PostAsync(requestUrl, httpContent).Result;
					if (response.IsSuccessStatusCode)
					{
						string responseData = await response.Content.ReadAsStringAsync();
						return responseData;
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

        public async Task<bool> Register(User _user)
        {
			try
			{
				using (var httpClient = new HttpClient()) 
				{ 
					httpClient.BaseAddress= new Uri(BaseUrl);
					var requestUrl = BaseUrl + "Create";
					//httpClient.DefaultRequestHeaders.ConnectionClose = true;
					//httpClient.DefaultRequestHeaders.Accept.Clear();
					//               httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
					httpClient.Timeout = TimeSpan.FromMinutes(10);
					string json=JsonConvert.SerializeObject(_user);
					StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
					HttpResponseMessage httpResponse =  httpClient.PostAsync(requestUrl, content).Result;
					if (httpResponse.IsSuccessStatusCode)
					{
						return true;
					}
					else
					{
						return false;
					}
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
        }

		
    }
}
