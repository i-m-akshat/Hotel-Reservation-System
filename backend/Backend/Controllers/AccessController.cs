using Backend.Models.Admin_Domain;
using Backend.Models.AppSettings_Domain;
using Backend.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Backend.Controllers
{
   
    
    [Route("api/[controller]")]
    [ApiController]
    
    public class AccessController : ControllerBase
    {
        private readonly IAccessService _service;
        private readonly ISecureService _secure;
        private readonly AppSettings _app;
        public AccessController(IAccessService service,ISecureService secure,IOptions<AppSettings> app)
        {
            _service = service;
            _secure = secure;
            _app = app.Value;
        }
        [HttpGet]
        [Route("")]
        public IActionResult Get()
        {
            return null;

        }
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Post([FromBody] string _Data)
        {
            var dec_data = _secure.Decrypt(_Data.ToString(), _app.enc_key, _app.enc_iv);
            var data = JsonConvert.DeserializeObject<Access>(dec_data);
            var res = await _service.Create(data);
            if (res != null) {
                var result=JsonConvert.SerializeObject(res);
                var enc_res = _secure.Encrypt(result, _app.enc_key, _app.enc_iv);
                return Ok(res);
            }
            else
            {
                return BadRequest();
            }

           
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
