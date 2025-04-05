using MensajeriaPaqueteria.Application.Dtos;
using MensajeriaPaqueteria.Domain.Entities;
using MensajeriaPaqueteria.Infrastructure.Repositories.PaqueteR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MensajeriaPaqueteria.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaquetesController : ControllerBase
    {
        private readonly IPaqueteRepository _paqueteRepository;

        public PaquetesController(IPaqueteRepository paqueteRepository)
        {
            _paqueteRepository = paqueteRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var paquetes = await _paqueteRepository.GetAllAsync();
            if (paquetes == null || !paquetes.Any())
                return NotFound("No se encontraron paquetes.");

            return Ok(paquetes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var paquete = await _paqueteRepository.GetByIdAsync(id);
            if (paquete == null)
                return NotFound($"Paquete con ID {id} no encontrado.");

            return Ok(paquete);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PaqueteDto paqueteDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var paquete = new Paquete
            {
                TipoPaquete = paqueteDto.TipoPaquete,
                Peso = paqueteDto.Peso,
                EstadoPaquete = paqueteDto.EstadoPaquete,
                FechaEnvio = paqueteDto.FechaEnvio,
                ClienteId = paqueteDto.ClienteId
            };

            await _paqueteRepository.AddAsync(paquete);
            return CreatedAtAction(nameof(GetById), new { id = paquete.PaqueteId }, paquete);
        }

        // ✅ Método PUT corregido
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PaqueteDto paqueteDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingPaquete = await _paqueteRepository.GetByIdAsync(id);
            if (existingPaquete == null)
                return NotFound($"Paquete con ID {id} no encontrado.");

            existingPaquete.TipoPaquete = paqueteDto.TipoPaquete;
            existingPaquete.Peso = paqueteDto.Peso;
            existingPaquete.EstadoPaquete = paqueteDto.EstadoPaquete;
            existingPaquete.FechaEnvio = paqueteDto.FechaEnvio;
            existingPaquete.ClienteId = paqueteDto.ClienteId;

            await _paqueteRepository.UpdateAsync(existingPaquete);

            // ✅ Solución: Devolver el paquete actualizado en vez de NoContent()
            return Ok(existingPaquete);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var paquete = await _paqueteRepository.GetByIdAsync(id);
            if (paquete == null)
                return NotFound($"Paquete con ID {id} no encontrado.");

            await _paqueteRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
