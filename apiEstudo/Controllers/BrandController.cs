using apiEstudo.Application.ServicesInterfaces;
using apiEstudo.Application.ViewModel.BrandViewModel;
using apiEstudo.Domain.Models;
using apiEstudo.Infraestrutura.RepositoriesInterfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace apiEstudo.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/v1/Brand")]
    public class BrandController : ControllerBase
    {         
        private readonly IBrandService _marcaService;

        public BrandController(IBrandService marcaService)
        {
            _marcaService = marcaService;
        }

        [HttpPost]
        public IActionResult Create(BrandCreateViewModel view)
        {
            var QueryResponse = _marcaService.Create(view);
            if (!QueryResponse) return NotFound();
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var Query= _marcaService.GetAll();
            
            if (Query == null || Query.Count() == 0) return NotFound();
            else return Ok(Query);
        }
    }
}
