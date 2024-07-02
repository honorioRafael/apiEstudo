using apiEstudo.Application.ViewModel;
using apiEstudo.Domain.DTOs;
using apiEstudo.Domain.Model;
using apiEstudo.Domain.Models;
using apiEstudo.Infraestrutura;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace apiEstudo.Controllers
{
    [ApiController]
    //[Authorize]
    [Route("api/v1/employee")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IEmployeeTaskRepository _taskRepository;

        public EmployeeController(IEmployeeRepository employeeRepository, IEmployeeTaskRepository taskRepository)
        {
            _employeeRepository = employeeRepository;
            _taskRepository = taskRepository;
        }

        /*[HttpPost]
        public IActionResult Add(EmployeeViewModel employeeView)
        {
            var employee = new Employee(employeeView.Name, employeeView.Age, employeeView.taskId);
            _employeeRepository.Add(employee);
            return Ok();
        }*/

        [HttpGet]
        public IActionResult GetAll()
        {
            var employess = _employeeRepository.GetAll();
            var resp = (from employee in employess select (EmployeeDTO)employee).ToList();

            if (resp == null || resp.Count() == 0) return NotFound();
            else return Ok(resp);
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var employee = _employeeRepository.Get(id);
            var resp = (EmployeeDTO)employee;

            if (resp == null) return NotFound();
            else return Ok(resp);
        }
    }

}