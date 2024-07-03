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
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        [HttpPost]
        public IActionResult Add(ProdutoViewModel produtoView)
        {
            var produto = new Produto(produtoView.Nome, produtoView.Quantidade, produtoView.MarcaId);
            _produtoRepository.Add(produto);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) 
        {
            var ProdutoToBeDeleted = _produtoRepository.Get(id);
            if(ProdutoToBeDeleted == null) return NotFound();

            _produtoRepository.Delete(ProdutoToBeDeleted);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, ProdutoViewModel produtoView)
        {
            var ProdutoToBeUpdated = _produtoRepository.Get(id);
            if(ProdutoToBeUpdated == null) return NotFound();
            
            ProdutoToBeUpdated.UpdateProduto(produtoView);
            _produtoRepository.Update(ProdutoToBeUpdated);
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAll() 
        {
            var query = _produtoRepository.GetAll();
            var resp = (from produto in query
                        select (ProdutoDTO)produto).ToList();

            if (resp == null) return NotFound();
            else return Ok(resp);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id) 
        { 
            var query = _produtoRepository.Get(id);
            if (query == null) return NotFound();
            else return Ok((ProdutoDTO)query);
        }
    }
}
