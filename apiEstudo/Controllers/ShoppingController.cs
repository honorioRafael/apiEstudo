//using apiEstudo.Application.ServicesInterfaces;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;

//namespace apiEstudo.Controllers
//{
//    [ApiController]
//    [Authorize]
//    [Route("api/v1/Shopping")]
//    public class ShoppingController : Controller
//    {
//        private readonly IShoppingService _compraService;

//        public ShoppingController(IShoppingService compraService)
//        {
//            _compraService = compraService;
//        }

//        [HttpPost]
//        public IActionResult Create(ShoppingCreateViewModel comprasView)
//        {
//            _compraService.Create(comprasView);
//            return Ok();
//        }

//        [HttpGet]
//        public IActionResult GetAll()
//        {
//            var Query = _compraService.GetAll();
//            if (Query == null) return NotFound();
//            return Ok(Query);
//        }

//        [HttpGet("{id}")]
//        public IActionResult Get(int id)
//        {
//            var Query = _compraService.Get(id);
//            if (Query == null) return NotFound();
//            return Ok(Query);
//        }
//    }
//}
