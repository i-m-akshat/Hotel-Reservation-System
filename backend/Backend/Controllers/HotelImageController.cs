using Backend.Models;
using Backend.Models.AppSettings_Domain;
using Backend.Models.Hotel_Domain;
using Backend.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelImageController : ControllerBase
    {
        private readonly IHotelImageService _service;
        private readonly ISecureService _secure;
        private readonly AppSettings _appSettings;
        public HotelImageController(IHotelImageService service, ISecureService secure, IOptions<AppSettings> appSettings)
        {
            _service = service;
            _secure = secure;
            _appSettings = appSettings.Value;

        }
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] string body)
        {
            try
            {
                var dec_data = _secure.Decrypt(body, _appSettings.enc_key, _appSettings.enc_iv);
                if (dec_data != null)
                {
                    var data = JsonConvert.DeserializeObject<HotelImage>(dec_data);
                    var res = await _service.CreateHotelImage(data);
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
                            IsSuccess = false,
                            StatusCode = 400,
                            StatusMessage = "Bad Request"
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
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAll([FromQuery] string count="")
        {
            try
            {
                int dec_count = 0;
                int TotalPages = 0;
                int totalPageSize = 5;
                if (count != "")
                {
                     dec_count = Convert.ToInt32(_secure.Decrypt(count, _appSettings.enc_key, _appSettings.enc_iv));
                }
                var res = await _service.GetAll();
                
                if (res != null)
                {
                    double totalCount = res.Count();
                    if (totalCount > 0)
                    {
                         TotalPages = Convert.ToInt32(Math.Ceiling((totalCount / totalPageSize)));
                        int skipCount = ((TotalPages + dec_count) - (TotalPages)) * totalPageSize;
                        res =res.Skip(skipCount).Take(totalPageSize).ToList();
                    }
                    return Ok(new ResponseGet<string>
                    {
                        IsSuccess = true,
                        StatusCode = 200,
                        StatusMessage = "Success",
                        Data = _secure.Encrypt(JsonConvert.SerializeObject(res), _appSettings.enc_key, _appSettings.enc_iv),
                        CurrentPageIndex=dec_count,
                        TotalPages=TotalPages,
                        PageSize=totalPageSize,
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
        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> GetById([FromQuery] string id)
        {
            try
            {
                long dec_id = Convert.ToInt64(_secure.Decrypt(id, _appSettings.enc_key, _appSettings.enc_iv));
                var res = await _service.GetHotelImage(dec_id);
                if (res != null)
                {
                    return Ok(new Response<string>
                    {
                        IsSuccess = true,
                        StatusCode = 200,
                        Data = _secure.Encrypt(JsonConvert.SerializeObject(res), _appSettings.enc_key, _appSettings.enc_iv),
                        StatusMessage = "OK"
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
        [HttpGet]
        [Route("GetByHotelID")]
        public async Task<IActionResult> GetByHotelId(string hotelId)
        {
            try
            {
                long dec_Hotelid = Convert.ToInt64(_secure.Decrypt(hotelId, _appSettings.enc_key, _appSettings.enc_iv));
                var res = await _service.GetHotelImagesByHotelId(dec_Hotelid);
                if (res != null)
                {

                    return Ok(new Response<string>
                    {
                        IsSuccess = true,
                        StatusCode = 200,
                        Data = _secure.Encrypt(JsonConvert.SerializeObject(res), _appSettings.enc_key, _appSettings.enc_iv),
                        StatusMessage = "OK"
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
        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update([FromQuery] string id, [FromBody] string image)
        {
            try
            {
                var dec_id = Convert.ToInt64(_secure.Decrypt(id, _appSettings.enc_key, _appSettings.enc_iv));
                var body = _secure.Decrypt(image, _appSettings.enc_key, _appSettings.enc_iv);
                if (dec_id != null && body != null)
                {
                    var hotelImg = JsonConvert.DeserializeObject<HotelImage>(body);
                    var res = await _service.UpdateHotelImage(dec_id, hotelImg);
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
        [Route("Delete")]
        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] string id)
        {
            try
            {
                var dec_id = Convert.ToInt64(_secure.Decrypt(id, _appSettings.enc_key, _appSettings.enc_iv));
                if (dec_id != null)
                {
                    var res = await _service.DeleteHotelImage(dec_id);
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
    }
}
