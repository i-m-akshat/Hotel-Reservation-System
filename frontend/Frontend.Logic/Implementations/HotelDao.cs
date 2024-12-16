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

        public Hotel_model AddHotel(string content)
        {
            throw new NotImplementedException();
        }

        public Hotel_model DeleteHotel(string id)
        {
            throw new NotImplementedException();
        }

        public List<Hotel_model> GetAllHotel()
        {
            throw new NotImplementedException();
        }

        public Hotel_model GetHotelById(string id)
        {
            throw new NotImplementedException();
        }

        public Hotel_model UpdateHotel(string content, string id)
        {
            throw new NotImplementedException();
        }
    }
}
