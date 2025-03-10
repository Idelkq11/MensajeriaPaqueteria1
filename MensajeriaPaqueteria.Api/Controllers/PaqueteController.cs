using Microsoft.AspNetCore.Mvc;
using MensajeriaPaqueteria.Domain.Entities;
using MensajeriaPaqueteria.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using MensajeriaPaqueteria.Infrastructure.Repositories.PaqueteR;

namespace MensajeriaPaqueteria.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaquetesController(IPaqueteRepository paqueteRepository) : ControllerBase
    {
        private readonly IPaqueteRepository _paqueteRepository = paqueteRepository;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var paquetes = await _paqueteRepository.GetAllAsync();
            return Ok(paquetes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var paquete = await _paqueteRepository.GetByIdAsync(id);
            if (paquete == null) return NotFound();
            return Ok(paquete);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Paquete paquete)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _paqueteRepository.AddAsync(paquete);
            return CreatedAtAction(nameof(GetById), new { id = paquete.Id }, paquete);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Paquete paquete)
        {
            if (id != paquete.Id) return BadRequest();
            await _paqueteRepository.UpdateAsync(paquete);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var paquete = await _paqueteRepository.GetByIdAsync(id);
            if (paquete == null) return NotFound();

            await _paqueteRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
