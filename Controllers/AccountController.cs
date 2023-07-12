using Microsoft.AspNetCore.Mvc;
using NHNT.Services;

namespace NHNT.Controllers
{
    [Route("[controller]")]
    public class AccountController : ControllerCustom
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("[action]")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("[action]")]
        public IActionResult Login([FromForm] string username, [FromForm] string password)
        {
            return Ok(_userService.Login(username, password));
        }

        [HttpPost("[action]")]
        public IActionResult RefreshToken([FromForm] string accessToken, [FromForm] string refreshToken)
        {
            return Ok(_userService.RefreshToken(accessToken, refreshToken));
        }
    }
}