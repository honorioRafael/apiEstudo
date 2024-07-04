using apiEstudo.Application.ServicesInterfaces;
using apiEstudo.Application.ViewModel;
using apiEstudo.Domain.DTOs;
using apiEstudo.Domain.Model;
using apiEstudo.Infraestrutura;
using apiEstudo.Infraestrutura.RepositoriesInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace apiEstudo.Controllers
{
    [ApiController]
    //[Authorize]
    [Route("api/v1/employee")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {           
            var query = _employeeService.GetAll();
            if (query == null || query.Count() == 0) return NotFound();
            else return Ok(query);            
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var query = _employeeService.Get(id);

            if (query == null) return NotFound();
            else return Ok(query);
        }

        [HttpPost]
        public IActionResult Add(EmployeeViewModel employeeView)
        {
            var QueryResponse = _employeeService.Create(employeeView);
            if (!QueryResponse) return NotFound();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, EmployeeViewModel employeeView) 
        {
            var QueryResponse = _employeeService.Update(id, employeeView);
            if (QueryResponse == false) return NotFound();
            return Ok();            
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) 
        {
            var QueryResponse = _employeeService.Delete(id);

            if(QueryResponse == false) return NotFound();
            return Ok();
        }
    }

}