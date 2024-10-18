using Backend.Models.AppSettings_Domain;
using Backend.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Backend.Models.City_Domain;
using Newtonsoft.Json;
namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityService _service;
        private readonly ISecureService _secure;
        private readonly AppSettings _appsetting;
        public CityController(ICityService serve,ISecureService secure,IOptions<AppSettings> appsettings)
        {
            _service = serve;   
            _secure = secure;
            _appsetting = appsettings.Value;
        }
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] string data)
        {
            if (data == null)
            {
                return BadRequest("please send the data");
            }
            else
            {
                string dec_data = _secure.Decrypt(data, _appsetting.enc_key, _appsetting.enc_iv) ;
                City_Model model = JsonConvert.DeserializeObject<City_Model>(dec_data);
                if (model != null) { 
                var res=await _service.Create(model);
                    if (res != null) { 
                        string enc_res=_secure.Encrypt(JsonConvert.SerializeObject(res),_appsetting.enc_key,_appsetting.enc_iv);
                        return Ok(enc_res);
                    }
                    else
                    {
                        return BadRequest("Something went wrong while creation");
                    }
                }
                else
                {
                    return BadRequest("please provide the valid values");
                }
            }
        }
            
    }
}
