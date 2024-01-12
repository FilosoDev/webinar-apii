using Oficina.WebApi.Models;
using Oficina.WebApi.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Oficina.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrosController : ControllerBase
    {
        private readonly CarroRepository _carroRepository;
        public CarrosController(CarroRepository carroRepository)
        {
            _carroRepository = carroRepository;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_carroRepository.Listar());
        }

        [HttpPost]
        public IActionResult Cadastrar(Carro carro)
        {
            _carroRepository.Cadastrar(carro);
            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Carro carro)
        {
            _carroRepository.Atualizar(id, carro);
            return StatusCode(204);
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                _carroRepository.Deletar(id);
                return StatusCode(204);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Carro carro = _carroRepository.BuscarporId(id);
            if (carro == null)
            {
                return NotFound();
            }
            return Ok(carro);
        }

        

    }
}
