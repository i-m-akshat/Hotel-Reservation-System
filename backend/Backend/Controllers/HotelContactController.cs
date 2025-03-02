using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Route("HotelContact")]
    public class HotelContactController : ControllerBase
    {

        [HttpGet]
        [Route("Get")]
        public IActionResult Get()
        {

        }
        [HttpGet]
        [Route("GetById")]
        public IActionResult GetByID()
        {

        }
        [HttpPost]
        public IActionResult Create()
        {

        }
        [HttpPut]
        public IActionResult Update()
        {

        }
        []
    }
}
