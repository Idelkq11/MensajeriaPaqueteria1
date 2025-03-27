using MensajeriaPaqueteria.Application.Dtos;
using MensajeriaPaqueteria.Domain.Entities;
using MensajeriaPaqueteria.Infrastructure.Repositories.MensajeroR;
using Microsoft.AspNetCore.Mvc;

namespace MensajeriaPaqueteria.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MensajeroController : ControllerBase
    {
        private readonly IMensajeroRepository _mensajeroRepository;

        public MensajeroController(IMensajeroRepository mensajeroRepository)
        {
            _mensajeroRepository = mensajeroRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var mensajeros = await _mensajeroRepository.GetAllAsync();
            if (mensajeros == null || !mensajeros.Any())
                return NotFound("No se encontraron mensajeros.");

            return Ok(mensajeros);
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var mensajero = await _mensajeroRepository.GetByIdAsync(id);
            if (mensajero == null)
                return NotFound($"Mensajero con ID {id} no encontrado.");

            return Ok(mensajero);
        }

        
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MensajeroDto mensajeroDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var mensajero = new Mensajero
            {
                Nombre = mensajeroDto.Nombre,
                Telefono = mensajeroDto.Telefono,
                Vehiculo = mensajeroDto.Vehiculo,
                Estado = mensajeroDto.Estado
            };

            await _mensajeroRepository.AddAsync(mensajero);
            return CreatedAtAction(nameof(GetById), new { id = mensajero.MensajeroId }, mensajero);
        }

      
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] MensajeroDto mensajeroDto)
        {
            if (id != mensajeroDto.MensajeroId)
                return BadRequest("El ID en la ruta no coincide con el ID del modelo.");

            var existingMensajero = await _mensajeroRepository.GetByIdAsync(id);
            if (existingMensajero == null)
                return NotFound($"Mensajero con ID {id} no encontrado.");

            existingMensajero.Nombre = mensajeroDto.Nombre;
            existingMensajero.Telefono = mensajeroDto.Telefono;
            existingMensajero.Vehiculo = mensajeroDto.Vehiculo;
            existingMensajero.Estado = mensajeroDto.Estado;

            await _mensajeroRepository.UpdateAsync(existingMensajero);
            return NoContent();
        }

      
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var mensajero = await _mensajeroRepository.GetByIdAsync(id);
            if (mensajero == null)
                return NotFound($"Mensajero con ID {id} no encontrado.");

            await _mensajeroRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}


