using apiEstudo.Application.ServicesInterfaces;
using apiEstudo.Application.ViewModel;
using apiEstudo.Domain.DTOs;
using apiEstudo.Domain.Model;
using apiEstudo.Domain.Models;
using apiEstudo.Infraestrutura.RepositoriesInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace apiEstudo.Controllers
{
    [ApiController]
    //[Authorize]
    [Route("api/v1/product")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public IActionResult Create(ProductViewModel productView)
        {
            var QueryResponse = _productService.Create(productView);
            if(!QueryResponse) return NotFound();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) 
        {
            var QueryResponse = _productService.Delete(id);
            if(!QueryResponse) return NotFound();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, ProductViewModel productView)
        {
            var QueryResponse = _productService.Update(id, productView);
            if(!QueryResponse) return NotFound();
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAll() 
        {
            var Query = _productService.GetAll();
            if(Query == null) return NotFound();
            return Ok(Query);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id) 
        { 
            var Query = _productService.Get(id);
            if (Query == null) return NotFound();
            else return Ok(Query);
        }
    }
}
