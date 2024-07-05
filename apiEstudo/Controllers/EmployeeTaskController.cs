﻿using apiEstudo.Application.ServicesInterfaces;
using apiEstudo.Application.ViewModel.EmployeeTaskViewModel;
using apiEstudo.Domain.DTOs;
using apiEstudo.Domain.Models;
using apiEstudo.Infraestrutura.RepositoriesInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace apiEstudo.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/v1/Task")]
    public class EmployeeTaskController : ControllerBase
    {
        private readonly IEmployeeTaskService _taskService;

        public EmployeeTaskController(IEmployeeTaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpPost]
        public IActionResult Add(EmployeeTaskCreateViewModel view)
        {
            var QueryResponse = _taskService.Create(view);
            if(!QueryResponse) return NotFound();
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var query = _taskService.GetAll();

            if (query == null || query.Count() == 0) return NotFound();
            else return Ok(query);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var QueryResponse = _taskService.Delete(id);
            if (!QueryResponse) return NotFound();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, EmployeeTaskCreateViewModel taskView)
        { 
            var QueryResponse = _taskService.Update(id, taskView);
            if (!QueryResponse) return NotFound();
            return Ok();
        }
    }
}