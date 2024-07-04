using Microsoft.AspNetCore.Mvc;
using apiEstudo.Domain.Model;
using apiEstudo.Application.Services;
using apiEstudo.Application.ServicesInterfaces;
using apiEstudo.Application.ViewModel;

namespace apiEstudo.Controllers
{
    [ApiController]
    [Route("api/v1/Auth")]
    public class AuthController : Controller
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("/NewUser")]
        public IActionResult Create(UserViewModel view)
        {
            var QueryResponse = _userService.Create(view);
            if (!QueryResponse) return NotFound();
            return Ok();
        }

        [HttpPost("/Login")]
        public IActionResult Auth(UserViewModel view)
        {
            var QueryResponse = _userService.Auth(view);
            
            if(QueryResponse)
            {
                var token = TokenService.GenerateToken(new Employee());
                return Ok(token);
            }

            return BadRequest("Usuário ou senha invalido.");
        }
    }
}
