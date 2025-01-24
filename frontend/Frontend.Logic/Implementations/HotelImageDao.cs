using Frontend.Logic.Interfaces;
using Frontend.Logic.Utility;
using System;
using System.Threading.Tasks;

namespace Frontend.Logic.Implementations
{
    public class HotelImageDao : IHotelImageDAO
    {
        private static readonly IRestUtility<string> _hitman=new RestUtility<string>();
        private static ISecureDAO _secureDao = new SecureDao();
        private static readonly string baseUrl="https://localhost:6969/api/HotelImage/";
        public async Task<string> AddHotelImage(string content)
        {
            try
            {
                return await _hitman.PostAsync(baseUrl, "Create", content);
            }
            catch (Exception ex)

            {

                throw;
            }
        }

        public async Task<string> DeleteHotelImage(string id)
        {
            try
            {
                return await _hitman.DeleteAsync(baseUrl, "Delete", id);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<string> GetAllHotelImages()
        {
            try
            {
                return await _hitman.GetAsync(baseUrl, "");
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<string> GetHotelImageByHotelID(string hotelID)
        {
            try
            {
                return await _hitman.GetByIDAsync(baseUrl, "GetByHotelID", hotelID);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<string> GetHotelImageById(string id)
        {
            try
            {
                return await _hitman.GetByIDAsync(baseUrl, "Get", id);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<string> UpdateHotelImage(string content, string id)
        {
            try
            {
                return await _hitman.PutAsync(baseUrl, "Update", id, content);
            }
            catch (Exception ex)
            {

                throw;
            }
           
        }
    }
}
