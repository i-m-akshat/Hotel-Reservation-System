using Backend.Models;
using Backend.Models.AppSettings_Domain;
using Backend.Models.Hotel_Domain;
using Backend.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Owin;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IHotelService _service;
        private readonly ISecureService _secure;
        private readonly AppSettings _appSettings;
        public HotelController(IHotelService service,ISecureService secure,IOptions<AppSettings> appSettings)
        {
            _service = service;
            _secure = secure; 
            _appSettings = appSettings.Value;
        }
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            try
            {
                var res = await _service.GetAllHotel();
                if (res.Count != 0) {
                    //return Ok();
                    return Ok(new Response<string>
                    {
                        StatusCode=200,
                        IsSuccess=true,
                        Data= _secure.Encrypt(JsonConvert.SerializeObject(res).ToString(), _appSettings.enc_key, _appSettings.enc_iv),
                        StatusMessage="Success"

                    });
                }
                else
                {
                    return NotFound(new Response<string>()
                    {
                        StatusCode=404,
                        IsSuccess=false,
                        StatusMessage="Data not found !",
                        
                    });
                }
            }
            catch (Exception ex)
            {

                return StatusCode(500, new Response<string>
                {
                    StatusCode = 500,
                    IsSuccess = false,
                    StatusMessage = "An error occurred while processing your request"
                });
            }

        }
        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> GetById([FromQuery]string id)
        {
            try
            {
                long dec_id = Convert.ToInt64(_secure.Decrypt(id, _appSettings.enc_key, _appSettings.enc_iv));
                var res = await _service.GetHotel(dec_id);
                if (res != null) {
                    return Ok(new Response<string>
                    {
                        IsSuccess=true,
                        StatusCode=200,
                        Data=_secure.Encrypt(JsonConvert.SerializeObject(res), _appSettings.enc_key, _appSettings.enc_iv),
                        StatusMessage="OK"
                    });
                }
                else
                {
                    return NotFound(new Response<string>
                    {
                        IsSuccess = false,
                        StatusCode = 404,
                        StatusMessage = "Not Found !"
                    });
                }
            }
            catch (Exception ex)
            {

                return StatusCode(500, new Response<string>
                {
                    StatusCode = 500,
                    IsSuccess = false,
                    StatusMessage = "An error occurred while processing your request"
                });
            }

        }
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody]string Content)
        {
            try
            {
                var dec_data=_secure.Decrypt(Content,_appSettings.enc_key,_appSettings.enc_iv);
                if (dec_data != null)
                {
                    var data = JsonConvert.DeserializeObject<Hotel>(dec_data);
                    var res = await _service.AddHotel(data);
                    if (res != null)
                    {
                        return Ok(new Response<string>
                        {
                            IsSuccess = true,
                            StatusCode = 201,
                            StatusMessage = "Success",
                            Data = _secure.Encrypt(JsonConvert.SerializeObject(res), _appSettings.enc_key, _appSettings.enc_iv)
                        });
                    }
                    else
                    {
                        return BadRequest(new Response<string>
                        {
                            IsSuccess=false,
                            StatusCode=400,
                            StatusMessage="Bad Request"
                        });
                    }
                }
                else
                {
                    return BadRequest(new Response<string>
                    {
                        IsSuccess = false,
                        StatusCode = 400,
                        StatusMessage = "Bad Request"
                    });
                }
            }
            catch (Exception ex)
            {

                return StatusCode(500, new Response<string>
                {
                    StatusCode = 500,
                    IsSuccess = false,
                    StatusMessage = "An error occurred while processing your request"
                });
            }
        }
        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update([FromBody]string Content, [FromQuery]string id)
        {
            try
            {
                var dec_id = Convert.ToInt64(_secure.Decrypt(id, _appSettings.enc_key, _appSettings.enc_iv));
                var dec_content = JsonConvert.DeserializeObject<Hotel>(_secure.Decrypt(Content, _appSettings.enc_key, _appSettings.enc_iv));
                var res = await _service.UpdateHotel(dec_content, dec_id);
                if (res != null)
                {
                    return Ok(new Response<string>
                    {
                        IsSuccess = true,
                        StatusCode = 200,
                        StatusMessage = "Success",
                        Data = _secure.Encrypt(JsonConvert.SerializeObject(res), _appSettings.enc_key, _appSettings.enc_iv)
                    });
                }
                else
                {
                    return BadRequest(new Response<string>
                    {
                        IsSuccess = false,
                        StatusCode = 400,
                        StatusMessage = "Bad Request"
                    });

                }
            }
            catch (Exception ex)
            {

                return StatusCode(500, new Response<string>
                {
                    StatusCode = 500,
                    IsSuccess = false,
                    StatusMessage = "An error occurred while processing your request"
                });
            }
            
           
        }
        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete([FromQuery] string id)
        {
            try
            {
                var dec_id = Convert.ToInt64(_secure.Decrypt(id, _appSettings.enc_key, _appSettings.enc_iv));
                if (dec_id != null)
                {
                    var res = await _service.DeleteHotel(dec_id);
                    if (res != null)
                    {
                        return Ok(new Response<string>
                        {
                            IsSuccess = true,
                            StatusCode = 200,
                            StatusMessage = "Success",
                            Data=_secure.Encrypt(JsonConvert.SerializeObject(res),_appSettings.enc_key,_appSettings.enc_iv)
                        });
                    } else
                    {
                        return NotFound(new Response<string>
                        {
                            IsSuccess=false,StatusMessage="Not Found",StatusCode=404
                        });
                    }
                }
                else
                {
                    return BadRequest(new Response<string>
                    {
                        IsSuccess=false,
                        StatusCode=400,
                        StatusMessage="Id have not been provided"
                    });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new Response<string>
                {
                    StatusCode = 500,
                    IsSuccess = false,
                    StatusMessage = "An error occurred while processing your request"
                });
            }
        }


    }
}
