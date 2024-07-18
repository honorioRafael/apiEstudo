using Microsoft.AspNetCore.Mvc;
using Study.Arguments.Arguments.Base;
using Study.Arguments.CustomException;
using Study.Domain.Interface.Service;

namespace Study.Api.Controllers.Base
{
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
        public virtual IActionResult GetAll()
        {
            var Query = _service.GetAll();
            return Ok(Query);
        }

        [HttpGet("{id}")]
        public virtual IActionResult Get(long id)
        {
            var Query = _service.Get(id);
            if (Query == null) return NotFound();
            return Ok(Query);
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