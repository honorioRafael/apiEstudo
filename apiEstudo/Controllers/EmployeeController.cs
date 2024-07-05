using apiEstudo.Application.Services;
using apiEstudo.Application.ServicesInterfaces;
using apiEstudo.Application.ViewModel.EmployeeViewModel;
using apiEstudo.Domain.DTOs;
using apiEstudo.Domain.Model;
using apiEstudo.Infraestrutura;
using apiEstudo.Infraestrutura.RepositoriesInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace apiEstudo.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/v1/Employee")]
    public class EmployeeController : BaseController<Employee, IEmployeeService, EmployeeDTO>
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService service) : base(service)
        {
        }

        /*public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }*/

        /*[HttpGet]
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
        }*/

        [HttpPost]
        public IActionResult Add(EmployeeCreateViewModel employeeView)
        {
            var QueryResponse = _service.Create(employeeView);
            if (!QueryResponse) return NotFound();
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(EmployeeUpdateViewModel employeeView) 
        {
            var QueryResponse = _service.Update(employeeView);
            if (QueryResponse == false) return NotFound();
            return Ok();            
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) 
        {
            var QueryResponse = _service.Delete(id);

            if(QueryResponse == false) return NotFound();
            return Ok();
        }
    }

}