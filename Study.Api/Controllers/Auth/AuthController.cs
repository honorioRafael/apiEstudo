using Microsoft.AspNetCore.Mvc;
using Study.Api.Controllers.Base;
using Study.Arguments.Arguments;
using Study.Arguments.Arguments.Base;
using Study.Arguments.CustomException;
using Study.Domain.Interface.Service;
using Study.Domain.Service.Token;

namespace Study.Api.Controllers
{
    [ApiController]
    [Route("api/v1/Auth")]
    public class AuthController : BaseController_2<IUserService, InputCreateUser, InputUpdateUser, InputIdentityUpdateUser, OutputUser>
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
        public IActionResult Auth(InputCreateUser inputCreateUser)
        {
            try
            {
                return Ok(_service.Auth(inputCreateUser));
            }
            catch (ArgumentNullException)
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
