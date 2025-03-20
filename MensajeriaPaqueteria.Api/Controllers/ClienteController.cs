using MensajeriaPaqueteria.Domain.Entities;
using MensajeriaPaqueteria.Infrastructure.Repositories.ClienteR;
using MensajeriaPaqueteria.Api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MensajeriaPaqueteria.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClienteViewModel>>> GetAll()
        {
            var clientes = await _clienteRepository.GetAllAsync();
            var clientesViewModel = clientes.Select(c => new ClienteViewModel
            {
                Id = c.Id,
                Nombre = c.Nombre,
                Direccion = c.Direccion,
                Telefono = c.Telefono
            });
            return Ok(clientesViewModel);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteViewModel>> GetById(int id)
        {
            var cliente = await _clienteRepository.GetByIdAsync(id);
            if (cliente == null) return NotFound();

            var clienteViewModel = new ClienteViewModel
            {
                Id = cliente.Id,
                Nombre = cliente.Nombre,
                Direccion = cliente.Direccion,
                Telefono = cliente.Telefono
            };

            return Ok(clienteViewModel);
        }

        [HttpPost]
        public async Task<ActionResult> Create(ClienteViewModel clienteViewModel)
        {
            var cliente = new Cliente
            {
                Nombre = clienteViewModel.Nombre,
                Direccion = clienteViewModel.Direccion,
                Telefono = clienteViewModel.Telefono
            };
            await _clienteRepository.AddAsync(cliente);
            return CreatedAtAction(nameof(GetById), new { id = cliente.Id }, clienteViewModel);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, ClienteViewModel clienteViewModel)
        {
            if (id != clienteViewModel.Id) return BadRequest();

            var cliente = new Cliente
            {
                Id = clienteViewModel.Id,
                Nombre = clienteViewModel.Nombre,
                Direccion = clienteViewModel.Direccion,
                Telefono = clienteViewModel.Telefono
            };

            await _clienteRepository.UpdateAsync(cliente);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _clienteRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}