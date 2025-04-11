using Microsoft.AspNetCore.SignalR;
using MensajeriaPaqueteria.Api.Hubs;
using MensajeriaPaqueteria.Application.Contract;
using MensajeriaPaqueteria.Application.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MensajeriaPaqueteria.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnvioController : ControllerBase
    {
        private readonly IHubContext<TrackingHub> _hubContext;
        private readonly IEnvioService _envioService;

        public EnvioController(IHubContext<TrackingHub> hubContext, IEnvioService envioService)
        {
            _hubContext = hubContext;
            _envioService = envioService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var envios = await _envioService.GetAllAsync();
            return envios == null ? NotFound("No se encontraron envíos.") : Ok(envios);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var envio = await _envioService.GetByIdAsync(id);
            return envio == null ? NotFound($"Envío con ID {id} no encontrado.") : Ok(envio);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EnvioDto envioDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _envioService.CreateAsync(envioDto);
            return result.IsSuccess
                ? CreatedAtAction(nameof(GetById), new { id = envioDto.EnvioId }, envioDto)
                : BadRequest(result.Message);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] EnvioDto envioDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != envioDto.EnvioId)
                return BadRequest("El ID del envío en la URL no coincide con el del cuerpo de la solicitud.");

            var result = await _envioService.UpdateAsync(id, envioDto);

            if (result.IsSuccess)
            {
                await _hubContext.Clients.All.SendAsync("ReceiveUpdate", id.ToString(), "Actualizado");
                return Ok(result.Message);
            }

            return NotFound(result.Message);
        }

        // Este es el método que debería estar bien mapeado
        [HttpPut("{id}/estado")]
        public async Task<IActionResult> CambiarEstado(int id, [FromBody] string nuevoEstado)

        {
            var result = await _envioService.CambiarEstadoAsync(id, nuevoEstado);

            if (result.IsSuccess)
            {
                await _hubContext.Clients.All.SendAsync("ReceiveUpdate", id.ToString(), nuevoEstado);
                return Ok(result.Message);
            }

            return NotFound(result.Message);
        }

        [HttpPut("{id}/ubicacion")]
        public async Task<IActionResult> ActualizarUbicacion(int id, [FromBody] string nuevaUbicacion)
        {
            var result = await _envioService.ActualizarUbicacionAsync(id, nuevaUbicacion);
            if (result.IsSuccess)
            {
                await _hubContext.Clients.All.SendAsync("ReceiveUpdate", id.ToString(), nuevaUbicacion);
                return Ok(result.Message);
            }

            return NotFound(result.Message);
        }

        [HttpPut("{id}/confirmar-entrega")]
        public async Task<IActionResult> ConfirmarEntrega(int id, [FromBody] string firmaBase64)
        {
            var result = await _envioService.ConfirmarEntregaAsync(id, firmaBase64);
            if (result.IsSuccess)
            {
                await _hubContext.Clients.All.SendAsync("ReceiveUpdate", id.ToString(), "Entregado");
                return Ok(result.Message);
            }

            return NotFound(result.Message);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _envioService.DeleteAsync(id);
            return result.IsSuccess ? NoContent() : NotFound(result.Message);
        }
    }
}
