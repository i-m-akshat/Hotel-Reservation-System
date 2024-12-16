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
        Hotel_model AddHotel(string content);
        Hotel_model UpdateHotel(string content, string id);
        Hotel_model DeleteHotel(string id);
        List<Hotel_model> GetAllHotel();
        Hotel_model GetHotelById(string id);

    }
}
