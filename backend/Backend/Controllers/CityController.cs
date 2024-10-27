using Backend.Models.AppSettings_Domain;
using Backend.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Backend.Models.City_Domain;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Backend.DTO.City;
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
        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> Get()
        {
            var res = await _service.Get();
            if (res != null)
            {
                return Ok(_secure.Encrypt(JsonConvert.SerializeObject(res).ToString(), _appsetting.enc_key, _appsetting.enc_iv));
            }
            else
            {
                return NoContent();
            }
        }
        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update(string id,string content)
        {
            var dec_id = _secure.Decrypt(id, _appsetting.enc_key, _appsetting.enc_iv);
            var dec_Content = _secure.Decrypt(content, _appsetting.enc_key, _appsetting.enc_iv);
            var realContent = JsonConvert.DeserializeObject<City_Model>(dec_Content);
            long id_real = Convert.ToInt64(dec_id);
            var res = _service.Update(realContent, id_real);
            if (res != null)
            {
                return Ok(_secure.Encrypt(JsonConvert.SerializeObject(res), _appsetting.enc_key, _appsetting.enc_iv));
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete(string id)
        {
            var dec_id = _secure.Decrypt(id, _appsetting.enc_key, _appsetting.enc_iv);
            long id_real = Convert.ToInt64(dec_id);
            var res = _service.Delete(id_real);
            if (res != null)
            {
                return Ok(_secure.Encrypt(JsonConvert.SerializeObject(res), _appsetting.enc_key, _appsetting.enc_iv));
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpGet]
        [Route("Get/{id}")]
        public async Task<IActionResult> GetById([FromRoute]string id)
        {
            var dec_id = _secure.Decrypt(id, _appsetting.enc_key, _appsetting.enc_iv);
            long id_real = Convert.ToInt64(dec_id);
            var res = _service.GetById(id_real);
            if (res != null)
            {
                return Ok(_secure.Encrypt(JsonConvert.SerializeObject(res), _appsetting.enc_key, _appsetting.enc_iv));
            }
            else
            {
                return BadRequest();
            }
        }


    }
}
