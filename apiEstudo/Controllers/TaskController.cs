using apiEstudo.Application.ViewModel;
using apiEstudo.Domain.DTOs;
using apiEstudo.Domain.Models;
using apiEstudo.Infraestrutura.RepositoriesInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace apiEstudo.Controllers
{
    [ApiController]
    //[Authorize]
    [Route("api/v1/Task")]
    public class TaskController : ControllerBase
    {
        private readonly IEmployeeTaskRepository _taskRepository;

        public TaskController(IEmployeeTaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        [HttpPost]
        public IActionResult Add(EmployeeTaskViewModel viewModel)
        {
            var task = new EmployeeTask(viewModel.Name, viewModel.Description);
            _taskRepository.Create(task);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var resp = _taskRepository.GetAll();

            if (resp == null || resp.Count() == 0) return NotFound();
            else return Ok(resp);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var TaskToDelete = _taskRepository.Get(id);
            if (TaskToDelete == null) return NotFound();

            //_taskRepository.Delete(TaskToDelete);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, EmployeeTaskViewModel taskView)
        { 
            var TaskToUpdate = _taskRepository.Get(id);
            if (TaskToUpdate == null) return NotFound();

            //TaskToUpdate.UpdateTask(taskView);
            //_taskRepository.Update(TaskToUpdate);
            return Ok();
        }
    }
}
