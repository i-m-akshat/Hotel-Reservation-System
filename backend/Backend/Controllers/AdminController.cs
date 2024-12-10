using Backend.Mappers;
using Backend.Models.Admin_Domain;
using Backend.Models.AppSettings_Domain;
using Backend.Models.Mail_Domain;
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
        private readonly IMailService _mail;
        private readonly AppSettings _app;
        public AdminController(IAdminService service, ISecureService secureservice, IOptions<AppSettings> app, IMailService mail)
        {
            _service = service;
            _secureService = secureservice;
            _app = app.Value;
            _mail = mail;
        }
        [HttpGet("Login")]
        public async Task<IActionResult> Login(string username)
        {
            var admin = await _service.GetByUserName(username);
            if (admin != null)
            {
                var enc_admin = _secureService.Encrypt(JsonConvert.SerializeObject(admin.ToAdminDTO()), _app.enc_key, _app.enc_iv);

                var message = @"
<!DOCTYPE html>
<html>
<head>
    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
            background-color: #f9f9f9;
        }
        .email-container {
            max-width: 600px;
            margin: 20px auto;
            background-color: #ffffff;
            border-radius: 10px;
            overflow: hidden;
            box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
            border: 1px solid #ddd;
        }
        .header {
            background-color: #007bff;
            color: #ffffff;
            padding: 20px;
            text-align: center;
        }
        .content {
            padding: 20px;
            font-size: 16px;
            color: #333333;
            line-height: 1.6;
        }
        .footer {
            background-color: #f4f4f4;
            text-align: center;
            padding: 15px;
            border-top: 1px solid #dddddd;
        }
        .footer img {
            width: 100px;
            margin-top: 10px;
        }
        .footer-title {
            margin-top: 5px;
            font-size: 14px;
            font-weight: bold;
            color: #333333;
        }
    </style>
</head>
<body>
    <div class='email-container'>
        <!-- Header -->
        <div class='header'>
            <h1>You're Logged In</h1>
        </div>

        <!-- Content -->
        <div class='content'>
            <p>Dear " + admin.FullName.ToString() + @",</p>
            <p>Welcome back! You have successfully logged in to your account.</p>
            <p>If you did not log in or believe this is an unauthorized access, please contact our support team immediately.</p>
            <p>Thank you,<br>The Akshat Group Team</p>
        </div>

        <!-- Footer -->
        <div class='footer'>
            <img src='' alt='Akshat Group Logo'>
            <div class='footer-title'>Akshat Group</div>
        </div>
    </div>
</body>
</html>";
                Email mail = new Email
                {
                    ToMail = "akshatdwivedi59941@gmail.com",
                    Subject = string.Format("Hi ! Welcome"),
                    Body = message,
                };

                bool isSuccess = await _mail.SendMailAsync(mail);
                return Ok(enc_admin);
            }
            else
            {
                return NotFound();
            }

        }
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] string data)
        {
            var dec_data = _secureService.Decrypt(data, _app.enc_key, _app.enc_iv);
            var realData = JsonConvert.DeserializeObject<Admin>(dec_data);
            var res = _service.Create(realData).Result;
            if (res != null)
            {
                return Ok(_secureService.Encrypt(JsonConvert.SerializeObject(res).ToString(), _app.enc_key, _app.enc_iv));

            }
            else
            {
                return BadRequest();
            }
        }
        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> Delete([FromQuery] string id)
        {
            var dec_id = _secureService.Decrypt(id, _app.enc_key, _app.enc_iv);
            var real = Convert.ToInt64(dec_id);
            var res = await _service.Delete(real);
            if (res != null)
            {
                return Ok(_secureService.Encrypt(JsonConvert.SerializeObject(res), _app.enc_key, _app.enc_iv));
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpGet]
        [Route("GetById")]
        public async Task<IActionResult> Get([FromQuery] string id)
        {
            var dec_id = _secureService.Decrypt(id, _app.enc_key, _app.enc_iv);
            var real = Convert.ToInt64(dec_id);
            var res=await _service.GetById(real);
            if (res != null)
            {
                return Ok(_secureService.Encrypt(JsonConvert.SerializeObject(res), _app.enc_key, _app.enc_iv));
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var res= await _service.GetAll();
            if (res != null)
            {
                return Ok(_secureService.Encrypt(JsonConvert.SerializeObject(res), _app.enc_key, _app.enc_iv));
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPut]
        [Route("Update")]
        public async Task<IActionResult> Update([FromBody] string content, [FromQuery] string id)
        {
            var dec_id = _secureService.Decrypt(id, _app.enc_key, _app.enc_iv);
            var real_id = Convert.ToInt64(dec_id);
            var _deccontent=_secureService.Decrypt(content,_app.enc_key,_app.enc_iv);
            var realData = JsonConvert.DeserializeObject<Admin>(_deccontent);
            var res = await _service.Update(realData, real_id);
            if (res != null)
            {
                return Ok(_secureService.Encrypt(JsonConvert.SerializeObject(res), _app.enc_key, _app.enc_iv));
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
