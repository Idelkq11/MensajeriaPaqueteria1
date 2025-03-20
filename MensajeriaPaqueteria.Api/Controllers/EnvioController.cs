using MensajeriaPaqueteria.Domain.Entities;
using MensajeriaPaqueteria.Infrastructure.Repositories.EnvioR;
using MensajeriaPaqueteria.Api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MensajeriaPaqueteria.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnvioController : ControllerBase
    {
        private readonly IEnvioRepository _envioRepository;

        public EnvioController(IEnvioRepository envioRepository)
        {
            _envioRepository = envioRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EnvioViewModel>>> GetAll()
        {
            var envios = await _envioRepository.GetAllAsync();
            var enviosViewModel = envios.Select(e => new EnvioViewModel
            {
                Id = e.Id,
                PaqueteId = e.PaqueteId,
                ClienteId = e.ClienteId,
                EmpleadoId = e.EmpleadoId,
                FechaEnvio = e.FechaEnvio,
                FechaEntrega = e.FechaEntrega,
                Estado = e.Estado,
                Nombre = $"{e.Cliente?.Nombre} - {e.Paquete?.Nombre}" // Ajustar según necesidad
            });

            return Ok(enviosViewModel);
        }

        // Obtener un envío por ID
        [HttpGet("{id}")]
        public async Task<ActionResult<EnvioViewModel>> GetById(int id)
        {
            var envio = await _envioRepository.GetByIdAsync(id);
            if (envio == null) return NotFound("Envío no encontrado.");

            var envioViewModel = new EnvioViewModel
            {
                Id = envio.Id,
                PaqueteId = envio.PaqueteId,
                ClienteId = envio.ClienteId,
                EmpleadoId = envio.EmpleadoId,
                FechaEnvio = envio.FechaEnvio,
                FechaEntrega = envio.FechaEntrega,
                Estado = envio.Estado,
                Nombre = $"{envio.Cliente?.Nombre} - {envio.Paquete?.Nombre}"
            };

            return Ok(envioViewModel);
        }

        // Crear un nuevo envío
        [HttpPost]
        public async Task<ActionResult> Create(EnvioViewModel envioViewModel)
        {
            var envio = new Envio
            {
                PaqueteId = envioViewModel.PaqueteId,
                ClienteId = envioViewModel.ClienteId,
                EmpleadoId = envioViewModel.EmpleadoId,
                FechaEnvio = envioViewModel.FechaEnvio,
                FechaEntrega = envioViewModel.FechaEntrega,
                Estado = envioViewModel.Estado
            };

            await _envioRepository.AddAsync(envio);
            return CreatedAtAction(nameof(GetById), new { id = envio.Id }, envioViewModel);
        }

        // Actualizar un envío existente
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, EnvioViewModel envioViewModel)
        {
            if (id != envioViewModel.Id) return BadRequest("El ID del envío no coincide.");

            var existingEnvio = await _envioRepository.GetByIdAsync(id);
            if (existingEnvio == null) return NotFound("Envío no encontrado.");

            existingEnvio.PaqueteId = envioViewModel.PaqueteId;
            existingEnvio.ClienteId = envioViewModel.ClienteId;
            existingEnvio.EmpleadoId = envioViewModel.EmpleadoId;
            existingEnvio.FechaEnvio = envioViewModel.FechaEnvio;
            existingEnvio.FechaEntrega = envioViewModel.FechaEntrega;
            existingEnvio.Estado = envioViewModel.Estado;

            await _envioRepository.UpdateAsync(existingEnvio);
            return NoContent();
        }

        // Eliminar un envío
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var envio = await _envioRepository.GetByIdAsync(id);
            if (envio == null) return NotFound("Envío no encontrado.");

            await _envioRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}

