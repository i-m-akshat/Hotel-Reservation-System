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
    public class HotelDao : IHotelDao
    {
        private readonly ISecureDAO secureDAO = new SecureDao();
        private readonly IRestUtility<string> _hitman = new RestUtility<string>();
        private readonly string BaseUrl = "https://localhost:6969/api/Hotel/";

        public async Task<string> AddHotel(string content)
        {
            return await _hitman.PostAsync(BaseUrl, "Create", content);
        }

        public async Task<string> DeleteHotel(string id)
        {
            return await _hitman.DeleteAsync(BaseUrl, "Delete", id);
        }

        public async Task<string> GetAllHotel()
        {
            return await _hitman.GetAsync(BaseUrl, "");
        }

        public async Task<string> GetHotelById(string id)
        {   
            return await _hitman.GetByIDAsync(BaseUrl, "Get", id);
        }

        public async Task<string> UpdateHotel(string content, string id)
        {
            return await _hitman.PutAsync(BaseUrl,"Update",id,content);
        }
    }
}
