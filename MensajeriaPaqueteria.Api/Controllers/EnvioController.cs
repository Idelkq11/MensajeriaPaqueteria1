using Microsoft.AspNetCore.Mvc;
using MensajeriaPaqueteria.Domain.Entities;
using MensajeriaPaqueteria.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using MensajeriaPaqueteria.Infrastructure.Repositories.EnvioR;

namespace MensajeriaPaqueteria.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnviosController(IEnvioRepository envioRepository) : ControllerBase
    {
        private readonly IEnvioRepository _envioRepository = envioRepository;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var envios = await _envioRepository.GetAllAsync();
            return Ok(envios);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var envio = await _envioRepository.GetByIdAsync(id);
            if (envio == null) return NotFound();
            return Ok(envio);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Envio envio)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _envioRepository.AddAsync(envio);
            return CreatedAtAction(nameof(GetById), new { id = envio.Id }, envio);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Envio envio)
        {
            if (id != envio.Id) return BadRequest();
            await _envioRepository.UpdateAsync(envio);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var envio = await _envioRepository.GetByIdAsync(id);
            if (envio == null) return NotFound();

            await _envioRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
