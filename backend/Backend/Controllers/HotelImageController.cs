using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelImageController : ControllerBase
    {
        [HttpPost]
        public IActionResult Create([FromBody] string body)
        {
            try
            {
                return null;
            }
            catch (Exception ex)
            {
                throw;
            }
          
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return null;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpGet]
        public IActionResult GetById([FromQuery] string id)
        {
            try
            {
                return null;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpGet]
        public IActionResult GetByHotelId(string hotelId) 
        {
            try
            {
                return null;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        [HttpPut]
        public IActionResult Update([FromQuery]string id, [FromBody] string image)
        {
            try
            {
                return null;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
