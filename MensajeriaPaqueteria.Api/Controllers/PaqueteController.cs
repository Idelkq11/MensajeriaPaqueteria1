using MensajeriaPaqueteria.Application.Dtos;
using MensajeriaPaqueteria.Application.Contract;
using Microsoft.AspNetCore.Mvc;

namespace MensajeriaPaqueteria.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaquetesController : ControllerBase
    {
        private readonly IPaqueteService _paqueteService;

        public PaquetesController(IPaqueteService paqueteService)
        {
            _paqueteService = paqueteService;
        }

       
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var paquetes = await _paqueteService.GetAllAsync();
            return Ok(paquetes);
        }

      
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var paquete = await _paqueteService.GetByIdAsync(id);
            if (paquete == null) return NotFound();
            return Ok(paquete);
        }

       
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PaqueteDto paqueteDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var paquete = new PaqueteDto
            {
                TipoPaquete = paqueteDto.TipoPaquete,
                Peso = paqueteDto.Peso,
                EstadoPaquete = paqueteDto.EstadoPaquete,
                FechaEnvio = paqueteDto.FechaEnvio,
                ClienteId = paqueteDto.ClienteId
            };

            await _paqueteService.CreateAsync(paquete);
            return CreatedAtAction(nameof(GetById), new { id = paqueteDto.PaqueteId }, paquete);
        }

      
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] PaqueteDto paqueteDto)
        {
            if (id != paqueteDto.PaqueteId) return BadRequest("El ID en la ruta no coincide con el ID del modelo.");

            var paquete = await _paqueteService.GetByIdAsync(id);
            if (paquete == null) return NotFound();

            await _paqueteService.UpdateAsync(id, paqueteDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var paquete = await _paqueteService.GetByIdAsync(id);
            if (paquete == null) return NotFound();

            await _paqueteService.DeleteAsync(id);
            return NoContent();
        }
    }
}
