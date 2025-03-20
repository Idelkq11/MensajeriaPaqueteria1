using Microsoft.AspNetCore.Mvc;
using MensajeriaPaqueteria.Domain.Entities;
using MensajeriaPaqueteria.Infrastructure.Repositories.PaqueteR;
using MensajeriaPaqueteria.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MensajeriaPaqueteria.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class PaquetesController : ControllerBase
    {
        private readonly IPaqueteRepository _paqueteRepository;

        public PaquetesController(IPaqueteRepository paqueteRepository)
        {
            _paqueteRepository = paqueteRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaqueteViewModel>>> GetAll()
        {
            var paquetes = await _paqueteRepository.GetAllAsync();
            var paquetesViewModel = paquetes.Select(p => new PaqueteViewModel
            {

                Id = p.Id,
                Nombre = p.Nombre,
                Peso = p.Peso,
                Estado = p.Estado,
                Descripcion = p.Descripcion,
                ClienteId = p.ClienteId,

            });

            return Ok(paquetesViewModel);
        }
    
        [HttpGet("{id}")]
        public async Task<ActionResult<PaqueteViewModel>> GetById(int id)
        {
            var paquete = await _paqueteRepository.GetByIdAsync(id);
            if (paquete == null) return NotFound();

            var paqueteViewModel = new PaqueteViewModel
            {

                Id = paquete.Id,
                Nombre = paquete.Nombre,
                Peso = paquete.Peso,
                Estado = paquete.Estado,
                Descripcion = paquete.Descripcion,
                ClienteId = paquete.ClienteId,


            };


            return Ok(paqueteViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(PaqueteViewModel paqueteViewModel)
        {
            

            var paquete = new Paquete
            {
                Nombre = paqueteViewModel.Nombre,
                Peso = paqueteViewModel.Peso,
                Estado = paqueteViewModel.Estado,
                Descripcion = paqueteViewModel.Descripcion,
                ClienteId = paqueteViewModel.ClienteId,
            };

            await _paqueteRepository.AddAsync(paquete);
            return CreatedAtAction(nameof(GetById), new { id = paquete.Id }, paqueteViewModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, PaqueteViewModel paqueteViewModel)
        {
            if (id !=paqueteViewModel.Id) return BadRequest();

            var paquete = new Paquete
            {
                Id = paqueteViewModel.Id,
                Nombre = paqueteViewModel.Nombre,
                Peso = paqueteViewModel.Peso,
                Estado = paqueteViewModel.Estado,
                Descripcion = paqueteViewModel.Descripcion,
                ClienteId = paqueteViewModel.ClienteId,


            };
           

            await _paqueteRepository.UpdateAsync(paquete);
            return CreatedAtAction(nameof(GetById), new { id = paquete.Id }, paqueteViewModel);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var paquete = await _paqueteRepository.GetByIdAsync(id);
            if (paquete == null) return NotFound($"Paquete con ID {id} no encontrado.");

            await _paqueteRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
