using Backend.DataAccessLayer.Repository.Interfaces;
using Backend.Models.Hotel_Domain;
using Backend.Services.Interfaces;
using Backend.Services.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Services.Implementatios
{
    public class HotelServices : IHotelService
    {
        private  readonly IHotelRepo _repo;
        public HotelServices(IHotelRepo repo)
        {
            _repo = repo;
        }
        public async Task<Hotel> AddHotel(Hotel hotel)
        {
            if (hotel != null)
            {
                hotel.CreatedDate = DateTime.Now;
                var res = await _repo.CreateHotel(hotel.ToTblHotel());
                if (res != null) {
                    return res.ToHotel();
                }
                else
                    return null;
            }
            else
                return null;
        }

        public async Task<Hotel> DeleteHotel(long id)
        {

            var tbl=await _repo.DeleteHotel(id);
            return tbl.ToHotel();
        }

        public async Task<List<Hotel>> GetAllHotel()
        {
           var tbl=await _repo.GetAllHotels();
            return tbl.Select(x=>x.ToHotelWithInclude_withoutImgs()).ToList();
        }

        public async Task<Hotel> GetHotel(long id)
        {
            var tbl = await _repo.GetHotelsByid(id);
            return tbl.ToHotelWithInclude();
        }

        public async Task<Hotel> UpdateHotel(Hotel hotel, long id)
        {
            hotel.UpdatedDate = DateTime.Now;
            var tbl=await _repo.UpdateHotel(hotel.ToTblHotel(), id);    
            return tbl.ToHotel();
        }
    }
}
