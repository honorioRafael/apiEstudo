using Microsoft.AspNetCore.Mvc;
using apiEstudo.Domain.Model;
using apiEstudo.Application.Services;

namespace apiEstudo.Controllers
{
    [ApiController]
    [Route("api/v1/auth")]
    public class AuthController : Controller
    {
        [HttpPost]
        public IActionResult Auth(string username, string password)
        {
            if(username == "user" && password == "1234")
            {
                var token = TokenService.GenerateToken(new Employee());
                return Ok(token);
            }

            return BadRequest("senha invalida");
        }
    }
}
