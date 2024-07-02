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
        private readonly ConnectionContext _context = new ConnectionContext();
        private readonly ITaskRepository _taskRepository;

        public EmployeeController(IEmployeeRepository employeeRepository, ITaskRepository taskRepository)
        {
            _employeeRepository = employeeRepository;
            _taskRepository = taskRepository;
        }

        [HttpPost]
        public IActionResult Add(EmployeeViewModel employeeView)
        {
            var employee = new Employee(employeeView.Name, employeeView.Age, employeeView.taskId);
            _employeeRepository.Add(employee);
            return Ok();
        }

        [HttpGet]
        public IActionResult Get()
        {
            var employess = _employeeRepository.Get(_context.Employees);
            var resp = (from employee in employess
                        select new EmployeeDTO
                        {
                            id = employee.id,
                            name = employee.name,
                            task = _taskRepository.GetTask(employee.taskId)
                        }).ToList();
            if (resp == null || resp.Count() == 0) return NotFound();
            else return Ok(resp);
        }

        [HttpGet("{id}")]
        public IActionResult GetId(int id)
        {
            var employess = _employeeRepository.Get(_context.Employees, x => x.id == id);
            var resp = (from employee in employess
                        select new EmployeeDTO
                        {
                            id = employee.id,
                            name = employee.name,
                            task = _taskRepository.GetTask(employee.taskId)
                        }).FirstOrDefault();
            if (resp == null) return NotFound();
            else return Ok(resp);
        }

        [HttpGet("name/{name}")]
        public IActionResult GetByName(string name)
        {
            var employess = _employeeRepository.Get(_context.Employees, x => x.name == name);
            var resp = (from employee in employess
                        select new EmployeeDTO
                        {
                            id = employee.id,
                            name = employee.name,
                            task = _taskRepository.GetTask(employee.taskId)
                        }).FirstOrDefault();
            if (resp == null) return NotFound();
            else return Ok(resp);

        }
    }
}