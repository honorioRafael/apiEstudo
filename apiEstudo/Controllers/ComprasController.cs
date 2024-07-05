using apiEstudo.Application.ServicesInterfaces;
using apiEstudo.Application.ViewModel;
using apiEstudo.Domain.DTOs;
using apiEstudo.Domain.Models;
using apiEstudo.Infraestrutura.Repositories;
using apiEstudo.Infraestrutura.RepositoriesInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace apiEstudo.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/v1/Compras")]
    public class ComprasController : Controller
    {
        private readonly IComprasService _compraService;

        public ComprasController(IComprasService compraService)
        {
            _compraService = compraService;
        }

        [HttpPost]
        public IActionResult Create(ComprasViewModel comprasView)
        {
            _compraService.Create(comprasView);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAll() 
        {
            var Query = _compraService.GetAll();
            if(Query == null) return NotFound();
            return Ok(Query);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var Query = _compraService.Get(id);
            if (Query == null) return NotFound();
            return Ok(Query);
        }
    }
}
