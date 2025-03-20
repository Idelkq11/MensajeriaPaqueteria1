using MensajeriaPaqueteria.Domain.Entities;
using MensajeriaPaqueteria.Infrastructure.Repositories.EmpleadoR;
using MensajeriaPaqueteria.Api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MensajeriaPaqueteria.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpleadoController : ControllerBase
    {
        private readonly IEmpleadoRepository _empleadoRepository;

        public EmpleadoController(IEmpleadoRepository empleadoRepository)
        {
            _empleadoRepository = empleadoRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmpleadoViewModel>>> GetAll()
        {
            var empleados = await _empleadoRepository.GetAllAsync();
            var empleadosViewModel = empleados.Select(e => new EmpleadoViewModel
            {
                Id = e.Id,
                Nombre = e.Nombre,
                Cargo = e.Cargo,
                Telefono = e.Telefono
            });
            return Ok(empleadosViewModel);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmpleadoViewModel>> GetById(int id)
        {
            var empleado = await _empleadoRepository.GetByIdAsync(id);
            if (empleado == null) return NotFound();
            var empleadoViewModel = new EmpleadoViewModel
            {
                Id = empleado.Id,
                Nombre = empleado.Nombre,
                Cargo = empleado.Cargo,
                Telefono = empleado.Telefono
            };
            return Ok(empleadoViewModel);
        }

        [HttpPost]
        public async Task<ActionResult> Create(EmpleadoViewModel empleadoViewModel)
        {
            var empleado = new Empleado
            {
                Nombre = empleadoViewModel.Nombre,
                Cargo = empleadoViewModel.Cargo,
                Telefono = empleadoViewModel.Telefono
            };
            await _empleadoRepository.AddAsync(empleado);
            return CreatedAtAction(nameof(GetById), new { id = empleado.Id }, empleadoViewModel);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, EmpleadoViewModel empleadoViewModel)
        {
            if (id != empleadoViewModel.Id) return BadRequest();

            var empleado = new Empleado
            {
                Id = empleadoViewModel.Id,
                Nombre = empleadoViewModel.Nombre,
                Cargo = empleadoViewModel.Cargo,
                Telefono = empleadoViewModel.Telefono
            };

            await _empleadoRepository.UpdateAsync(empleado);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _empleadoRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}