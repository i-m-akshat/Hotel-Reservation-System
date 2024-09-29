using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Backend.Services.Interfaces;
using Backend.Mappers;
using Backend.Domain.User_Domain;
using Backend.DTO.User;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
        public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        public UserController(IUserService service)
        {
            _service= service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var Users=await _service.GetAll();
            return Ok(Users.Select(x => x.ToUserDto_Common()));
        }
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] User_registerDto _userDto)
        {
            var user=await _service.CreateUser(_userDto.ToUserModelFromRegisterDTO());
            return Ok(user.ToUserDto_Common());
        }
        
        [Route("GetUser")]
        [HttpPost]
        public async Task<IActionResult> GetByUsername([FromBody] User_loginDto _userDto)
            {
            var User=await _service.GetUserByUserNameAndPassword(_userDto.UserID,_userDto.Password);
            if (User == null) {
                return BadRequest("Provided Username and password is not valid");
            } else
            {
                return Ok(User.ToLoginDTO());
            }
            
        }
        // [Route]
        [HttpGet("GetByUserId")]
        public async Task<IActionResult> GetByUserId([FromQuery]string userid){
            var _user=await _service.GetUserByUserName(userid);
            if (_user == null) {
                return BadRequest("No User exists by this id");
            } else
            {
                return Ok(_user.ToLoginDTO());
            }
        }
    }
}
