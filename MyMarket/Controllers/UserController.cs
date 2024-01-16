using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MyMarket.Services;
using Services;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly UserService _userService ;
        private readonly IConfiguration _configuration;

        public UserController(IConfiguration configuration)
        {
            _userService = new UserService();
            _configuration = configuration;
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            try
            {
                return Ok(_userService.GetAll());
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error", error = ex.Message });
            }
        }

        [HttpGet]
        public IActionResult GetUser([FromBody] User user)
        {
            try
            {
                return Ok(_userService.GetUser(user));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Internal server error", error = ex.Message });
            }
        }
    }
}
