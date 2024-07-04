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
        private readonly IEmployeeRepository _employeeRepository; //
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeRepository employeeRepository, IEmployeeTaskRepository taskRepository, IEmployeeService employeeService)
        {
            _employeeRepository = employeeRepository;
            _employeeService = employeeService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {           
            var query = _employeeService.GetAll();
            if (query == null || query.Count() == 0) return NotFound();
            else return Ok(from item in query select (EmployeeDTO)item);            
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var query = _employeeService.Get(id);

            if (query == null) return NotFound();
            else return Ok((EmployeeDTO)query);
        }

        [HttpPost]
        public IActionResult Add(EmployeeViewModel employeeView)
        {
            var employee = new Employee(employeeView.Name, employeeView.Age, employeeView.taskId);
            _employeeRepository.Create(employee);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, EmployeeViewModel employeeView) 
        {
            var queryResponse = _employeeService.Update(id, employeeView);
            if (queryResponse == false) return NotFound();
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