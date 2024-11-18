using Backend.Models.Admin_Domain;
using Backend.Models.AppSettings_Domain;
using Backend.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController:ControllerBase
    {
        private readonly IRoleService _dal;
        private readonly ISecureService _secureService;
        private readonly AppSettings _app;
        public RoleController(IRoleService dal,ISecureService service,IOptions<AppSettings> app)
        {
            _dal = dal;
            _secureService = service;
            _app = app.Value;
        }

        [HttpGet]
        [Route("")]
        public  async Task<IActionResult> Get()
        {
            var res = await _dal.getAll();
            if (res == null) {
            return NoContent();
            } else
            {
                var enc_res = _secureService.Encrypt(JsonConvert.SerializeObject(res).ToString(), _app.enc_key, _app.enc_iv);
                return Ok(enc_res);
            }
            
        }
        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> Get([FromQuery]string id) {
            var dec_id=_secureService.Decrypt(id ,_app.enc_key,_app.enc_iv);
            long _id = Convert.ToInt64(dec_id);
            var res=await _dal.GetById(_id);
            if (res == null) {

                return NotFound();
            }
            else
            {
                return Ok((_secureService.Encrypt(JsonConvert.SerializeObject(res).ToString()),_app.enc_key,_app.enc_iv));
            }
        }
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody]string data)
        {
            var dec_data = _secureService.Decrypt(data, _app.enc_key, _app.enc_iv);
            var _data=JsonConvert.DeserializeObject<Role>(dec_data);
            var res = await _dal.Create(_data);
            if (res == null) {
                return BadRequest();
            
            } else {
            return Ok(_secureService.Encrypt(JsonConvert.SerializeObject(_data),_app.enc_key,_app.enc_iv));
            }

        }
        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update([FromBody]string data, [FromQuery]string id) {

            var dec_id=Convert.ToInt64(_secureService.Decrypt(id,_app.enc_key,_app.enc_iv));
            var dec_data = JsonConvert.DeserializeObject<Role>(_secureService.Decrypt(data, _app.enc_key, _app.enc_iv));
            if (dec_data == null) {
                return BadRequest();
            }
            else
            {
                var res = await _dal.Update(dec_data, dec_id);
                if (res == null)
                {
                    return BadRequest();
                }
                else
                {
                    return Ok((JsonConvert.SerializeObject(res).ToString(), _app.enc_key, _app.enc_iv));
                }
            }
           
        }
        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete([FromQuery]string id) {

            var dec_id = Convert.ToInt64(_secureService.Decrypt(id, _app.enc_key, _app.enc_iv));
            var res=await _dal.Delete(dec_id);
            if(res == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(_secureService.Encrypt(res.ToString(), _app.enc_key, _app.enc_iv));
            }
        }



    }
}
