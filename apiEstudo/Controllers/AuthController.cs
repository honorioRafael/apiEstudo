using Microsoft.AspNetCore.Mvc;
using apiEstudo.Domain.Model;
using apiEstudo.Application.Services;
using apiEstudo.Application.ServicesInterfaces;
using apiEstudo.Domain.Models;
using apiEstudo.Application.ViewModel.UserViewModel;

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

        [HttpPost]
        public IActionResult Create(UserCreateViewModel view)
        {
            try
            {
                _userService.Create(view);
                return Ok();
            }
            catch (ArgumentNullException ex)
            {
                return NotFound();
            }
            catch (NameInUseException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Login")]
        public IActionResult Auth(UserCreateViewModel view)
        {
            try
            {
                User? UserAccount = _userService.Auth(view);

                var token = TokenService.GenerateToken(UserAccount);
                return Ok(token);
                
            }
            catch (ArgumentNullException ex)
            {
                return NotFound();
            }
            catch (WrongPasswordException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
