﻿using apiEstudo.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace apiEstudo.Controllers
{
    /*[ApiController]
    [Route("api/v1/marca")]
    public class MarcaController : ControllerBase
    { 
        private readonly IMarcaRepository _marcaRepository;

        public MarcaController(IMarcaRepository marcaRepository)
        {
            _marcaRepository = marcaRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var resp = _marcaRepository.GetAll();

            if (resp == null || resp.Count() == 0) return NotFound();
            else return Ok(resp);
        }
    }*/
}