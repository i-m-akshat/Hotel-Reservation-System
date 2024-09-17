﻿
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
		//private readonly string BaserUrl = "https://localhost:7218/api/User/";
		//private readonly string BaserUrl = "https://localhost:5211/api/User/";
		private readonly string BaserUrl = "https://localhost:6969/api/User/";
		public async Task<bool> Register(User _user)
        {
			try
			{
				using (var httpClient = new HttpClient()) 
				{ 
					httpClient.BaseAddress= new Uri(BaserUrl);
					var requestUrl = BaserUrl + "Create";
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
