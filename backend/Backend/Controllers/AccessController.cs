using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccessController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        
        public IActionResult Get()
        {
            return null;

        }
        [HttpPost]
        [Route("Create")]
        public IActionResult Post([FromBody] string _Data) {

            return null;
        }
        [HttpPut]
        [Route("Update")]
        public IActionResult Put(string _Data, string id)
        {
            return null;
        }
        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete(string id) {
            return null;
        }
        [HttpGet]
        [Route("Get")]
        public IActionResult Get(string id) {

            return null;

        }
    }
}
