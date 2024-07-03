using apiEstudo.Application.ViewModel;
using apiEstudo.Domain.DTOs;
using apiEstudo.Domain.Models;
using apiEstudo.Infraestrutura.Repositories;
using apiEstudo.Infraestrutura.RepositoriesInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace apiEstudo.Controllers
{
    [ApiController]
    [Route("api/v1/Compras")]
    public class ComprasController : Controller
    {
        private readonly ICompraRepository _compraRepository;

        public ComprasController(ICompraRepository compraRepository)
        {
            _compraRepository = compraRepository;
        }

        [HttpPost]
        public IActionResult Add(ComprasViewModel comprasView)
        {
            var compra = new Compras(comprasView.Employeeid, comprasView.Produtoid, comprasView.Valor);
            _compraRepository.Add(compra);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAll() 
        {
            var query = _compraRepository.GetAll();
            var resp = (from compra in query
                        select (ComprasDTO)compra).ToList();
            return (resp == null) ? NotFound() : Ok(resp);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var query = _compraRepository.Get(id);
            var resp = (ComprasDTO)query;
            return (resp == null) ? NotFound() : Ok(resp);
        }
    }
}
