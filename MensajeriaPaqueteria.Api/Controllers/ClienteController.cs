using MensajeriaPaqueteria.Application.Dtos;
using MensajeriaPaqueteria.Domain.Entities;
using MensajeriaPaqueteria.Infrastructure.Repositories.ClienteR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MensajeriaPaqueteria.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var clientes = await _clienteRepository.GetAllAsync();
            if (clientes == null || !clientes.Any())
                return NotFound("No se encontraron clientes.");

            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var cliente = await _clienteRepository.GetByIdAsync(id);
            if (cliente == null)
                return NotFound($"Cliente con ID {id} no encontrado.");

            return Ok(cliente);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ClienteDto clienteDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var cliente = new Cliente
            {
                Nombre = clienteDto.Nombre,
                Direccion = clienteDto.Direccion,
                Telefono = clienteDto.Telefono
            };

            await _clienteRepository.AddAsync(cliente);
            return CreatedAtAction(nameof(GetById), new { id = cliente.ClienteId }, cliente);
        }

        // ✅ Método PUT corregido
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ClienteDto clienteDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingCliente = await _clienteRepository.GetByIdAsync(id);
            if (existingCliente == null)
                return NotFound($"Cliente con ID {id} no encontrado.");

            existingCliente.Nombre = clienteDto.Nombre;
            existingCliente.Direccion = clienteDto.Direccion;
            existingCliente.Telefono = clienteDto.Telefono;

            await _clienteRepository.UpdateAsync(existingCliente);

            // ✅ Solución: Devolver el cliente actualizado en vez de NoContent()
            return Ok(existingCliente);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var cliente = await _clienteRepository.GetByIdAsync(id);
            if (cliente == null)
                return NotFound($"Cliente con ID {id} no encontrado.");

            await _clienteRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}