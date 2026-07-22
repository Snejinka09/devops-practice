using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using MiniBank.Api.Service;
using MiniBank.Core.Entities;
using MiniBank.Core.Services;

namespace MiniBank.Api.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly UserService _userService;
        private readonly TokenService _tokenService;
        public AuthController(UserService userService, TokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public void Register(string login, string password)
        {
            _userService.Register(login, password);
        }

        [HttpPost("login")]
        public IActionResult Login(string login, string password)
        {
            var user = _userService.Login(login, password);
            if (user == null)
            {
                return Unauthorized();
            }
            else
            {
                var token = _tokenService.GenerateToken(user);
                return Ok(token);
            }
                
        }
    }
}
