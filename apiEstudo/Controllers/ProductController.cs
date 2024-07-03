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
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpPost]
        public IActionResult Add(ProductViewModel productView)
        {
            var product = new Product(productView.Name, productView.Quantity, productView.BrandId);
            _productRepository.Add(product);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) 
        {
            var ProductToBeDeleted = _productRepository.Get(id);
            if(ProductToBeDeleted == null) return NotFound();

            _productRepository.Delete(ProductToBeDeleted);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, ProductViewModel productView)
        {
            var ProductToBeUpdated = _productRepository.Get(id);
            if(ProductToBeUpdated == null) return NotFound();
            
            ProductToBeUpdated.UpdateProduct(productView);
            _productRepository.Update(ProductToBeUpdated);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAll() 
        {
            var query = _productRepository.GetAll();
            var resp = (from product in query
                        select (ProductDTO)product).ToList();

            if (resp == null) return NotFound();
            else return Ok(resp);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id) 
        { 
            var query = _productRepository.Get(id);
            if (query == null) return NotFound();
            else return Ok((ProductDTO)query);
        }
    }
}
