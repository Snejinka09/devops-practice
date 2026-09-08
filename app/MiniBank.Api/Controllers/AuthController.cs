using Microsoft.AspNetCore.Mvc;
using MiniBank.Api.Service;
using MiniBank.Core.Entities;
using MiniBank.Core.Services;
using MiniBank.Api.Dto;

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
        public void Register([FromBody] RegisterRequest request)
        {
            _userService.Register(request.Login, request.Password, request.ClientId);
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var user = _userService.Login(request.Login, request.Password);
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
