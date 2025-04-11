using Microsoft.AspNetCore.Mvc;
using MensajeriaPaqueteria.Application.Services;
using MensajeriaPaqueteria.Application.Dtos;

namespace MensajeriaPaqueteria.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UbicacionController : ControllerBase
    {
        private readonly IUbicacionService _ubicacionService;

        public UbicacionController(IUbicacionService ubicacionService)
        {
            _ubicacionService = ubicacionService;
        }

        // Endpoint para actualizar la ubicación del mensajero
        [HttpPost]
        public async Task<IActionResult> ActualizarUbicacion([FromBody] UbicacionDto dto)
        {
            if (dto == null)
            {
                return BadRequest("Los datos de la ubicación no son válidos.");
            }

            await _ubicacionService.ActualizarUbicacionAsync(dto);
            return Ok("Ubicación actualizada exitosamente.");
        }

        // Endpoint para obtener la última ubicación del mensajero
        [HttpGet("{mensajeroId}")]
        public async Task<IActionResult> ObtenerUbicacionActual(int mensajeroId)
        {
            var ubicacion = await _ubicacionService.ObtenerUltimaUbicacionAsync(mensajeroId);
            if (ubicacion == null)
            {
                return NotFound($"No se encontró ubicación para el mensajero con ID {mensajeroId}.");
            }

            return Ok(ubicacion);
        }
    }
}
