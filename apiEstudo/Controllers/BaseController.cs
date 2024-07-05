using apiEstudo.Application.Arguments;
using apiEstudo.Application.Arguments.Base;
using apiEstudo.Application.Arguments.BaseViewModel;
using apiEstudo.Application.ServicesInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace apiEstudo.Controllers
{
    public class BaseController<TService, TInputCreate, TInputUpdate, TInputIdentityUpdate, TInputIdentityDelete, TOutput> : ControllerBase
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

        [HttpGet]
        public IActionResult GetAll()
        {
            var Query = _service.GetAll();
            return Ok(Query);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var Query = _service.Get(id);
            if (Query == null) return NotFound();
            return Ok(Query);
        }

        [HttpPost]
        public IActionResult Create(TInputCreate inputCreate)
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
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut]
        public IActionResult Update(TInputIdentityUpdate inputIdentityUpdate)
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
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult Delete(TInputIdentityDelete inputIdentityDelete)
        {
            try
            {
                _service.Delete(inputIdentityDelete);
                return Ok();
            }
            catch (ArgumentNullException ex)
            {
                return NotFound();
            }
            //Exceptions customizadas / tratativas
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
