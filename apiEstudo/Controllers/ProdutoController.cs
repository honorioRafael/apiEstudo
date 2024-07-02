﻿using apiEstudo.Domain.DTOs;
using apiEstudo.Domain.Models;
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