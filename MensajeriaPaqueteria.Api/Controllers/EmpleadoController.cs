using Microsoft.AspNetCore.Mvc;
using MensajeriaPaqueteria.Domain.Entities;
using MensajeriaPaqueteria.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using MensajeriaPaqueteria.Infrastructure.Repositories.EmpleadoR;

namespace MensajeriaPaqueteria.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadosController(IEmpleadoRepository empleadoRepository) : ControllerBase
    {
        private readonly IEmpleadoRepository _empleadoRepository = empleadoRepository;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var empleados = await _empleadoRepository.GetAllAsync();
            return Ok(empleados);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var empleado = await _empleadoRepository.GetByIdAsync(id);
            if (empleado == null) return NotFound();
            return Ok(empleado);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Empleado empleado)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _empleadoRepository.AddAsync(empleado);
            return CreatedAtAction(nameof(GetById), new { id = empleado.Id }, empleado);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Empleado empleado)
        {
            if (id != empleado.Id) return BadRequest();
            await _empleadoRepository.UpdateAsync(empleado);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var empleado = await _empleadoRepository.GetByIdAsync(id);
            if (empleado == null) return NotFound();

            await _empleadoRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}

