using apiEstudo.Application.ServicesInterfaces;
using apiEstudo.Domain.DTOs;
using apiEstudo.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace apiEstudo.Controllers
{
    public class BaseController<Type, TService, TDTO> : ControllerBase
        where Type : IBaseModel<Type>
        where TDTO : IBaseDTO<TDTO> 
        where TService : IBaseService<Type, TDTO>
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
    }
}
