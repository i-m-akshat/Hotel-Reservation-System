using Frontend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.Logic.Interfaces
{
    public interface IHotelDao
    {
        Task<string> AddHotel(string content);
        Task<string> UpdateHotel(string content, string id);
        Task<string> DeleteHotel(string id);
        Task<string> GetAllHotel();
        Task<string> GetHotelById(string id);

    }
}
