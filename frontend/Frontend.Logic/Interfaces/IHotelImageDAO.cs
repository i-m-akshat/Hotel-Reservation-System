using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frontend.Logic.Interfaces
{
   public interface IHotelImageDAO
    {
        Task<string> AddHotelImage(string content);
        Task<string> UpdateHotelImage(string content, string id);
        Task<string> DeleteHotelImage(string id);
        Task<string> GetAllHotelImages();
        Task<string> GetHotelImageById(string id);
        Task<string> GetHotelImageByHotelID(string hotelID);
    }
}
