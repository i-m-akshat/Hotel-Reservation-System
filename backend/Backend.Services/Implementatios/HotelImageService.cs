using Backend.DataAccessLayer.Context.Models;
using Backend.DataAccessLayer.Repository.Interfaces;
using Backend.Models.Hotel_Domain;
using Backend.Services.Interfaces;
using Backend.Services.Mapper;

namespace Backend.Services.Implementatios
{
    public class HotelImageService : IHotelImageService
    {
        private readonly IHotelImageRepo _repo;
        public HotelImageService(IHotelImageRepo repo)
        {
            _repo = repo;
        }
        public async Task<HotelImage> CreateHotelImage(HotelImage hotelImage)
        {
            try
            {
                var tbl = await _repo.AddHotelImage(hotelImage.ToTblHotelImage());
                return tbl.ToHotelImage_ExcludingHotel();

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<HotelImage> DeleteHotelImage(long imageId)
        {
            try
            {
                var tbl = await _repo.DeleteHotelImage(imageId);
                if (tbl != null) {
               return tbl.ToHotelImage_ExcludingHotel() ;

                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<List<HotelImage>> GetAll()
        {
            try
            {
             
                var list = await _repo.GetAllImages();
                if (list != null)   
                {
                    return list.Select(x => x.ToHotelImage()).ToList();
                }
                else
                    return null;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<HotelImage> GetHotelImage(long imageId)
        {
            try
            {
                var tbl=await _repo.GetImageById(imageId);
                return tbl.ToHotelImage();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<List<HotelImage>> GetHotelImagesByHotelId(long hotelId)
        {
            try
            {
                var tbl=await _repo.GetImages_HotelID(hotelId);
                return tbl.Select(x=>x.ToHotelImage()).ToList();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<HotelImage> UpdateHotelImage(long imageId, HotelImage hotelImage)
        {
            try
            {
                var tbl = await _repo.UpdateHotelImage(imageId, hotelImage.ToTblHotelImage());
                return tbl.ToHotelImage_ExcludingHotel() ; 
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
