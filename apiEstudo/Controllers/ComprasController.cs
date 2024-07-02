using apiEstudo.Domain.DTOs;
using apiEstudo.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace apiEstudo.Controllers
{
    [ApiController]
    [Route("/Compras")]
    public class ComprasController : Controller
    {
        private readonly ICompraRepository _compraRepository;

        public ComprasController(ICompraRepository compraRepository)
        {
            _compraRepository = compraRepository;
        }

        [HttpGet]
        public IActionResult GetAll() 
        {
            var query = _compraRepository.GetAll();
            var resp = (from compra in query
                        select (ComprasDTO)compra).ToList();
            return (resp == null) ? NotFound() : Ok(resp);
        }
    }
}
