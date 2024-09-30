using Backend.DTO.Country;
using Backend.Mappers;
using Backend.Models.Admin_Domain;
using Backend.Models.AppSettings_Domain;
using Backend.Models.Country_Domain;
using Backend.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _service;
        private readonly ISecureService _secureService;
        private readonly AppSettings _app;
        public CountryController(ICountryService service, ISecureService secureservice, IOptions<AppSettings> app)
        {
            _service=service;
            _secureService = secureservice;
            _app = app.Value;
        }
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] string country)
        {
            var decCount = _secureService.Decrypt(country, _app.enc_key, _app.enc_iv);
            var country_obj=JsonConvert.DeserializeObject<Country_DTO>(decCount);
            var count = country_obj.ToCountryFromDTO();
            
            var res=await _service.Create(count);
            if(res==null) 
                return BadRequest("Something went wrong");
            else 
                    return Ok(res);
        }
        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> Get()
        {
            var res = await _service.GetAll();
            if (res == null)
                return BadRequest("Something went wrong");
            else
            {
                var res_DTO = res.Select(x => x.ToCountryDTO_Return());
                var enc_res = _secureService.Encrypt(JsonConvert.SerializeObject(res_DTO), _app.enc_key, _app.enc_iv);
                return Ok(enc_res);
            }
                
        }
    }
}
