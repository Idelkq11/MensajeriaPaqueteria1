using Microsoft.AspNetCore.Mvc;
using MensajeriaPaqueteria.Domain.Entities;
using MensajeriaPaqueteria.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using MensajeriaPaqueteria.Infrastructure.Repositories.RutaR;

namespace MensajeriaPaqueteria.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RutasController(IRutaRepository rutaRepository) : ControllerBase
    {
        private readonly IRutaRepository _rutaRepository = rutaRepository;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var rutas = await _rutaRepository.GetAllAsync();
            return Ok(rutas);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var ruta = await _rutaRepository.GetByIdAsync(id);
            if (ruta == null) return NotFound();
            return Ok(ruta);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Ruta ruta)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _rutaRepository.AddAsync(ruta);
            return CreatedAtAction(nameof(GetById), new { id = ruta.Id }, ruta);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Ruta ruta)
        {
            if (id != ruta.Id) return BadRequest();
            await _rutaRepository.UpdateAsync(ruta);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var ruta = await _rutaRepository.GetByIdAsync(id);
            if (ruta == null) return NotFound();

            await _rutaRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
