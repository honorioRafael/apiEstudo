//using apiEstudo.Application.ServicesInterfaces;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;

//namespace apiEstudo.Controllers
//{
//    [ApiController]
//    [Authorize]
//    [Route("api/v1/Task")]
//    public class EmployeeTaskController : ControllerBase
//    {
//        private readonly IEmployeeTaskService _taskService;

//        public EmployeeTaskController(IEmployeeTaskService taskService)
//        {
//            _taskService = taskService;
//        }

//        [HttpPost]
//        public IActionResult Create(EmployeeTaskCreateViewModel view)
//        {
//            var QueryResponse = _taskService.Create(view);
//            if (!QueryResponse) return NotFound();
//            return Ok();
//        }

//        [HttpGet]
//        public IActionResult GetAll()
//        {
//            var query = _taskService.GetAll();

//            if (query == null || query.Count() == 0) return NotFound();
//            else return Ok(query);
//        }

//        [HttpDelete("{id}")]
//        public IActionResult Delete(int id)
//        {
//            var QueryResponse = _taskService.Delete(id);
//            if (!QueryResponse) return NotFound();
//            return Ok();
//        }

//        [HttpPut]
//        public IActionResult Update(EmployeeTaskUpdateViewModel taskView)
//        {
//            var QueryResponse = _taskService.Update(taskView);
//            if (!QueryResponse) return NotFound();
//            return Ok();
//        }
//    }
//}
