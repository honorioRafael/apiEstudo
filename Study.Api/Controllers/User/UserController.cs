using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Study.Api.Controllers.Base;
using Study.Arguments.Arguments;
using Study.Arguments.Arguments.Base;
using Study.Arguments.CustomException;
using Study.Domain.Interface.Service;
using Study.Domain.Service.Token;

namespace Study.Api.Controllers
{
    public class UserController : BaseController_2<IUserService, InputCreateUser, InputUpdateUser, InputIdentityUpdateUser, OutputUser>
    {
        public UserController(IUserService service) : base(service)
        { }

        [HttpPost]
        public override IActionResult Create(InputCreateUser inputCreateUser)
        {
            try
            {
                _service.Create(inputCreateUser);
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
        [AllowAnonymous]
        public IActionResult Auth(InputLoginUser inputLoginUser)
        {
            try
            {
                return Ok(_service.Auth(inputLoginUser));
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
        public override ActionResult<OutputUser> Get(long id)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [ApiExplorerSettings(IgnoreApi = true)]
        public override ActionResult<List<OutputUser>> GetAll()
        {
            throw new NotImplementedException();
        }

    }
}
