//using apiEstudo.Application.ServicesInterfaces;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;

//namespace apiEstudo.Controllers
//{
//    [ApiController]
//    [Authorize]
//    [Route("api/v1/Product")]
//    public class ProductController : ControllerBase
//    {
//        private readonly IProductService _productService;

//        public ProductController(IProductService productService)
//        {
//            _productService = productService;
//        }

//        [HttpPost]
//        public IActionResult Create(ProductCreateViewModel productView)
//        {
//            var QueryResponse = _productService.Create(productView);
//            if (!QueryResponse) return NotFound();
//            return Ok();
//        }

//        [HttpDelete("{id}")]
//        public IActionResult Delete(int id)
//        {
//            var QueryResponse = _productService.Delete(id);
//            if (!QueryResponse) return NotFound();
//            return Ok();
//        }

//        [HttpPut]
//        public IActionResult Update(ProductUpdateViewModel productView)
//        {
//            var QueryResponse = _productService.Update(productView);
//            if (!QueryResponse) return NotFound();
//            return Ok();
//        }

//        [HttpGet]
//        public IActionResult GetAll()
//        {
//            var Query = _productService.GetAll();
//            if (Query == null) return NotFound();
//            return Ok(Query);
//        }

//        [HttpGet("{id}")]
//        public IActionResult Get(int id)
//        {
//            var Query = _productService.Get(id);
//            if (Query == null) return NotFound();
//            else return Ok(Query);
//        }
//    }
//}
