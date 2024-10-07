
using Backend.DTO.State;
using Backend.Mappers;
using Backend.Models.AppSettings_Domain;
using Backend.Models.State_Domain;
using Backend.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class StateController : ControllerBase
    {
        private readonly ISecureService _secureService;
        private readonly IStateService _stateService;
        private readonly AppSettings _app;
        public StateController(ISecureService secure,IStateService service,IOptions<AppSettings> app)
        {
            _secureService = secure;
            _stateService = service;
            _app = app.Value;
        }
        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            List<State> data = await _stateService.GetAll();
            if (data != null)
            {
                return Ok(_secureService.Encrypt(JsonConvert.SerializeObject(data.Select(x => x.ToDtoFromState_All())), _app.enc_key,_app.enc_iv));
            }else
            {
                return null;
            }
        }
        //[HttpGet]
        //Route["{id}"]
        //public async Task<IActionResult> GetById([FromRoute] int id)
        //{

        //}
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] string state)
        {
            var data=_secureService.Decrypt(state,_app.enc_key,_app.enc_iv);
            State state_model = JsonConvert.DeserializeObject<State_DTO>(data).ToStateFromDTO();
            var res=await _stateService.Create(state_model);
            if (res != null)
            {
                return Ok(_secureService.Encrypt(JsonConvert.SerializeObject(res.ToDtoFromState()),_app.enc_key,_app.enc_iv));
            }
            else
            {
                return BadRequest();
            }


        }
        
    }
}
