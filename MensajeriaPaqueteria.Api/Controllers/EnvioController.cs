using MensajeriaPaqueteria.Application.Dtos;
using MensajeriaPaqueteria.Domain.Entities;
using MensajeriaPaqueteria.Infrastructure.Repositories.EnvioR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MensajeriaPaqueteria.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnvioController : ControllerBase
    {
        private readonly IEnvioRepository _envioRepository;

        public EnvioController(IEnvioRepository envioRepository)
        {
            _envioRepository = envioRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var envios = await _envioRepository.GetAllAsync();
            if (envios == null || !envios.Any())
                return NotFound("No se encontraron envíos.");

            return Ok(envios);
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var envio = await _envioRepository.GetByIdAsync(id);
            if (envio == null)
                return NotFound($"Envío con ID {id} no encontrado.");

            return Ok(envio);
        }

      
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EnvioDto envioDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var envio = new Envio
            {
                FechaEnvio = envioDto.FechaEnvio,
                Direccion = envioDto.Direccion,
                PaqueteId = envioDto.PaqueteId
            };

            await _envioRepository.AddAsync(envio);
            return CreatedAtAction(nameof(GetById), new { id = envio.EnvioId }, envio);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] EnvioDto envioDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingEnvio = await _envioRepository.GetByIdAsync(id);
            if (existingEnvio == null)
                return NotFound($"Envío con ID {id} no encontrado.");

            existingEnvio.FechaEnvio = envioDto.FechaEnvio;
            existingEnvio.Direccion = envioDto.Direccion;
            existingEnvio.PaqueteId = envioDto.PaqueteId;

            await _envioRepository.UpdateAsync(existingEnvio);
            return NoContent();
        }

      
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var envio = await _envioRepository.GetByIdAsync(id);
            if (envio == null)
                return NotFound($"Envío con ID {id} no encontrado.");

            await _envioRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}


