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

        [HttpGet]
        public IActionResult GetAll()
        {
            var employess = _employeeRepository.GetAll();
            var resp = (from employee in employess select (EmployeeDTO)employee).ToList();

            if (resp == null || resp.Count() == 0) return NotFound();
            else return Ok(resp);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var employee = _employeeRepository.Get(id);
            var resp = (EmployeeDTO)employee;

            if (resp == null) return NotFound();
            else return Ok(resp);
        }

        [HttpPost]
        public IActionResult Add(EmployeeViewModel employeeView)
        {
            var employee = new Employee(employeeView.Name, employeeView.Age, employeeView.taskId);
            _employeeRepository.Add(employee);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Edit(int id, EmployeeViewModel employeeView) 
        {
            var employeeToUpdate = _employeeRepository.Get(id);
            if (employeeToUpdate == null) return NotFound();
            
            employeeToUpdate.UpdateEmployee(employeeView);
            _employeeRepository.Update(employeeToUpdate);
            return Ok();            
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) 
        { 
            var employeeToDelete = _employeeRepository.Get(id);
            if(employeeToDelete == null) return NotFound();

            _employeeRepository.Delete(employeeToDelete);
            return Ok();
        }
    }

}