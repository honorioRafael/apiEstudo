using apiEstudo.Application.ViewModel;
using apiEstudo.Domain.Model;
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

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException();
        }

        [HttpPost]
        public IActionResult Add(EmployeeViewModel employeeView)
        {
            var employee = new Employee(employeeView.Name, employeeView.Age);
            _employeeRepository.Add(employee);
            return Ok();
        }

        [HttpGet]
        public IActionResult Get()
        {
            var employess = _employeeRepository.Get();
            if (employess.Count() == 0) return NotFound();
            else return Ok(employess);
        }

        [HttpGet("{id}")]
        public IActionResult GetId(int id)
        {
            var employee = _employeeRepository.Get(id);
            if (employee == null) return NotFound();
            else return Ok(employee);
        }

        [HttpGet("name/{name}")]
        public IActionResult GetByName(string name)
        {
            var employee = _employeeRepository.Get(name);
            if (employee == null) return NotFound();
            else return Ok(employee);

        }
    }
}