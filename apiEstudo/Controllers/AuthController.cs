using apiEstudo.Application;
using apiEstudo.Application.Arguments;
using apiEstudo.Application.Services;
using apiEstudo.Application.ServicesInterfaces;
using apiEstudo.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace apiEstudo.Controllers
{
    [ApiController]
    [Route("api/v1/Auth")]
    public class AuthController : BaseController<IUserService, InputCreateUser, InputUpdateUser, InputIdentityUpdateUser, BaseInputIdentityDelete_0, OutputUser>
    {
        public AuthController(IUserService service) : base(service)
        { }

        [HttpPost]
        public override IActionResult Create(InputCreateUser view)
        {
            try
            {
                _service.Create(view);
                return Ok();
            }
            catch (ArgumentNullException)
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
        public IActionResult Auth(InputCreateUser view)
        {
            try
            {
                User? UserAccount = _service.Auth(view);

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

        [HttpPost("Multiple")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public override IActionResult CreateMultiple(List<InputCreateUser> listInputCreate)
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        [ApiExplorerSettings(IgnoreApi = true)]
        public override IActionResult Delete(BaseInputIdentityDelete_0 inputIdentityDelete)
        {
            throw new NotImplementedException();
        }

        [HttpPut("Multiple")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public override IActionResult UpdateMultiple(List<InputIdentityUpdateUser> listInputIdentityUpdate)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("Multiple")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public override IActionResult DeleteMultiple(List<BaseInputIdentityDelete_0> listInputIdentityDelete)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id}")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public override IActionResult Get(long id)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [ApiExplorerSettings(IgnoreApi = true)]
        public override IActionResult GetAll()
        {
            throw new NotImplementedException();
        }

    }
}
