using apiEstudo.Application;
using apiEstudo.Application.Arguments;
using apiEstudo.Application.ServicesInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace apiEstudo.Controllers
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

        [HttpPost]
        public virtual IActionResult Create(TInputCreate inputCreate)
        {
            try
            {
                return Ok(_service.Create(inputCreate));
            }
            //Exceptions customizadas / tratativas
            catch (ArgumentNullException ex)
            {
                return NotFound();
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


        [HttpPut]
        public virtual IActionResult Update(TInputIdentityUpdate inputIdentityUpdate)
        {
            try
            {
                return Ok(_service.Update(inputIdentityUpdate));
            }
            //Exceptions customizadas / tratativas
            catch (ArgumentNullException ex)
            {
                return NotFound();
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
                return NotFound();
            }
            catch (NotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            //Exceptions customizadas / tratativas
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public virtual IActionResult GetAll()
        {
            var Query = _service.GetAll();
            return Ok(Query);
        }

        [HttpGet("{id}")]
        public virtual IActionResult Get(int id)
        {
            var Query = _service.Get(id);
            if (Query == null) return NotFound();
            return Ok(Query);
        }
    }

    public abstract class BaseController_1<TService, TOutput> : BaseController<TService, BaseInputCreate_0, BaseInputUpdate_0, BaseInputIdentityUpdate_0, BaseInputIdentityDelete_0, TOutput>
        where TService : IBaseService_1<TOutput>
        where TOutput : BaseOutput<TOutput>
    {
        public BaseController_1(TService service) : base(service) { }
    }
}