using Backend.Mappers;
using Backend.Models.AppSettings_Domain;
using Backend.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _service;
        private readonly ISecureService _secureService;
        private readonly AppSettings _app;
        public AdminController(IAdminService service,ISecureService secureservice,IOptions<AppSettings> app)
        {
            _service = service;
            _secureService = secureservice;
            _app=app.Value;
        }
        [HttpGet("Login")]
        public async Task<IActionResult> Login( string username)
        {
            var admin=await _service.GetByUserName(username);
            if (admin != null)
            {
                var enc_admin = _secureService.Encrypt(JsonConvert.SerializeObject(admin.ToAdminDTO()), _app.enc_key, _app.enc_iv);
                return Ok(enc_admin);
            }
            else
            {
                return NotFound();
            }
            
        }
        //[HttpPost]
        //public async Task<IActionResult> Create([FromBody] int id)
        //{
        //    return BadRequest();
        //}
    }
}
