
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Backend.Services.Interfaces;
namespace Backend.Controllers
{
    [ApiController]
    [Route("api/auth")]
    
    public class AuthController : Controller
    {
        private readonly ISecureService _secure;
        public AuthController(ISecureService secure)
        {
            _secure= secure;    
        }
        //[HttpGet]
        //public IActionResult Login()
        //{
        //    return View();
        //}
        //[HttpGet]
        //public IActionResult Logout() 
        //{
        //    return View();
        //}
        //[HttpPost]
        //public IActionResult Register()
        //{
        //    return View();
        //}

    }
}









//scaffold-dbcontext "Server=DESKTOP-RBREH2D\SQLEXPRESS;Database=Basera_HotelReservationSystem;Trusted_Connection=True;Trust Server Certificate=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir "A:\asp.net Projects\HotelReservation\backend\Backend.DataAccessLayer\Context\Models" -ContextDir "A:\asp.net Projects\HotelReservation\backend\Backend.DataAccessLayer\Context\DBContext"