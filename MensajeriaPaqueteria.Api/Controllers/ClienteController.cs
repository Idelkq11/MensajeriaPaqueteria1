using Microsoft.AspNetCore.Mvc;
using MensajeriaPaqueteria.Domain.Entities;
using MensajeriaPaqueteria.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using MensajeriaPaqueteria.Infrastructure.Repositories.ClienteR;

namespace MensajeriaPaqueteria.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController(IClienteRepository clienteRepository) : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository = clienteRepository;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var clientes = await _clienteRepository.GetAllAsync();
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var cliente = await _clienteRepository.GetByIdAsync(id);
            if (cliente == null) return NotFound();
            return Ok(cliente);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Cliente cliente)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _clienteRepository.AddAsync(cliente);
            return CreatedAtAction(nameof(GetById), new { id = cliente.Id }, cliente);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Cliente cliente)
        {
            if (id != cliente.Id) return BadRequest();
            await _clienteRepository.UpdateAsync(cliente);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var cliente = await _clienteRepository.GetByIdAsync(id);
            if (cliente == null) return NotFound();

            await _clienteRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
