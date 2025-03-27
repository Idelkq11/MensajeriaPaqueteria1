using MensajeriaPaqueteria.Application.Dtos;
using MensajeriaPaqueteria.Application.Contract;
using MensajeriaPaqueteria.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MensajeriaPaqueteria.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RutasController : ControllerBase
    {
        private readonly IRutaService _rutaService;

        public RutasController(IRutaService rutaService)
        {
            _rutaService = rutaService;
        }

       
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var rutas = await _rutaService.GetAllAsync();
            if (rutas == null || !rutas.Any())
                return NotFound("No se encontraron rutas.");

            return Ok(rutas);
        }

       
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var ruta = await _rutaService.GetByIdAsync(id);
            if (ruta == null)
                return NotFound($"Ruta con ID {id} no encontrada.");

            return Ok(ruta);
        }

        
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] RutaDto rutaDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var ruta = new Ruta
            {
                Origen = rutaDto.Origen,
                Destino = rutaDto.Destino,
                EstadoRuta = rutaDto.EstadoRuta,
                MensajeroId = rutaDto.MensajeroId
            };

            await _rutaService.CreateAsync(rutaDto);
            return CreatedAtAction(nameof(GetById), new { id = rutaDto.RutaId }, rutaDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] RutaDto rutaDto)
        {
            if (id != rutaDto.RutaId)
                return BadRequest("El ID en la ruta no coincide con el ID del modelo.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingRuta = await _rutaService.GetByIdAsync(id);
            if (existingRuta == null)
                return NotFound($"Ruta con ID {id} no encontrada.");

            await _rutaService.UpdateAsync(id, rutaDto);
            return NoContent();
        }

       
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var ruta = await _rutaService.GetByIdAsync(id);
            if (ruta == null)
                return NotFound($"Ruta con ID {id} no encontrada.");

            await _rutaService.DeleteAsync(id);
            return NoContent();
        }
    }
}
