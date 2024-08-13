using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Study.Arguments.Arguments.Base;
using Study.Arguments.CustomException;
using Study.Domain.Interface.Service;

namespace Study.Api.Controllers.Base
{
    [ApiController]
    [Authorize]
    [Route("api/v1/[controller]")]
    public abstract class BaseController<TService, TInputCreate, TInputUpdate, TInputIdentityUpdate, TInputIdentityDelete, TOutput> : ControllerBase
        where TService : IBaseService<TInputCreate, TInputUpdate, TInputIdentityUpdate, TInputIdentityDelete, TOutput>
        where TInputCreate : BaseInputCreate<TInputCreate>
        where TInputUpdate : BaseInputUpdate<TInputUpdate>
        where TInputIdentityUpdate : BaseInputIdentityUpdate<TInputUpdate>
        where TInputIdentityDelete : BaseInputIdentityDelete<TInputIdentityDelete>
        where TOutput : BaseOutput<TOutput>
    {
        protected readonly TService _service;

        public BaseController(TService service)
        {
            _service = service;
        }

        #region Create / Post
        [HttpPost]
        public virtual IActionResult Create(TInputCreate inputCreate)
        {
            try
            {
                return Ok(_service.Create(inputCreate));
            }
            catch (ArgumentNullException)
            {
                return BadRequest("A lista está vazia");
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (InvalidArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("Multiple")]
        public virtual IActionResult CreateMultiple(List<TInputCreate> listInputCreate)
        {
            try
            {
                return Ok(_service.CreateMultiple(listInputCreate));
            }
            catch (ArgumentNullException)
            {
                return BadRequest("A lista está vazia");
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (InvalidArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion

        #region Update / Put
        [HttpPut]
        public virtual IActionResult Update(TInputIdentityUpdate inputIdentityUpdate)
        {
            try
            {
                return Ok(_service.Update(inputIdentityUpdate));
            }
            catch (ArgumentNullException)
            {
                return BadRequest("A lista está vazia");
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (InvalidArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Multiple")]
        public virtual IActionResult UpdateMultiple(List<TInputIdentityUpdate> listInputIdentityUpdate)
        {
            try
            {
                return Ok(_service.UpdateMultiple(listInputIdentityUpdate));
            }
            catch (ArgumentNullException)
            {
                return BadRequest("A lista está vazia");
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (InvalidArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion

        #region Delete
        [HttpDelete]
        public virtual IActionResult Delete(TInputIdentityDelete inputIdentityDelete)
        {
            try
            {
                _service.Delete(inputIdentityDelete);
                return Ok();
            }
            catch (ArgumentNullException)
            {
                return BadRequest("A lista está vazia");
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("Multiple")]
        public virtual IActionResult DeleteMultiple(List<TInputIdentityDelete> listInputIdentityDelete)
        {
            try
            {
                _service.DeleteMultiple(listInputIdentityDelete);
                return Ok();
            }
            catch (ArgumentNullException)
            {
                return BadRequest("A lista está vazia");
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion

        #region Get
        [HttpGet]
        public virtual ActionResult<List<TOutput>> GetAll()
        {
            var query = _service.GetAll();
            return Ok(query);
        }

        [HttpGet("{id}")]
        public virtual ActionResult<TOutput> Get(long id)
        {
            var query = _service.Get(id);
            if (query == null) return NotFound();
            return Ok(query);
        }

        #endregion
    }

    public abstract class BaseController_1<TService, TOutput> : BaseController<TService, BaseInputCreate_0, BaseInputUpdate_0, BaseInputIdentityUpdate_0, BaseInputIdentityDelete_0, TOutput>
        where TService : IBaseService_1<TOutput>
        where TOutput : BaseOutput<TOutput>
    {
        public BaseController_1(TService service) : base(service) { }
    }

    public abstract class BaseController_2<TService, TInputCreate, TInputUpdate, TInputIdentityUpdate, TOutput> : BaseController<TService, TInputCreate, TInputUpdate, TInputIdentityUpdate, BaseInputIdentityDelete_0, TOutput>
        where TService : IBaseService_2<TInputCreate, TInputUpdate, TInputIdentityUpdate, TOutput>
        where TInputCreate : BaseInputCreate<TInputCreate>
        where TInputUpdate : BaseInputUpdate<TInputUpdate>
        where TInputIdentityUpdate : BaseInputIdentityUpdate<TInputUpdate>
        where TOutput : BaseOutput<TOutput>
    {
        protected BaseController_2(TService service) : base(service)
        { }
    }
}