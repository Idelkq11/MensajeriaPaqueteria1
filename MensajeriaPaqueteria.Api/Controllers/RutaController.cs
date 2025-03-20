using MensajeriaPaqueteria.Domain.Entities;
using MensajeriaPaqueteria.Infrastructure.Repositories.RutaR;
using MensajeriaPaqueteria.Api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MensajeriaPaqueteria.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RutaController : ControllerBase
    {
        private readonly IRutaRepository _rutaRepository;

        public RutaController(IRutaRepository rutaRepository)
        {
            _rutaRepository = rutaRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RutaViewModel>>> GetAll()
        {
            var rutas = await _rutaRepository.GetAllAsync();
            var rutasViewModel = rutas.Select(r => new RutaViewModel
            {
                Id = r.Id,
                Origen = r.Origen,
                Destino = r.Destino,
                Distancia = r.Distancia,
                Envio = new EnvioViewModel
                // Asegúrate de que esta relación se maneje bien
                {
                    // Aquí deberías mapear las propiedades correspondientes de Envio a EnvioViewModel
                }
            });

            return Ok(rutasViewModel);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RutaViewModel>> GetById(int id)
        {
            var ruta = await _rutaRepository.GetByIdAsync(id);
            if (ruta == null) return NotFound();

            var rutaViewModel = new RutaViewModel
            {
                Id = ruta.Id,
                Origen = ruta.Origen,
                Destino = ruta.Destino,
                Distancia = ruta.Distancia,
                Envio = new EnvioViewModel // Asegúrate de que esta relación se maneje bien
                {
                    // Aquí deberías mapear las propiedades correspondientes de Envio a EnvioViewModel
                }
            };

            return Ok(rutaViewModel);
        }

        [HttpPost]
        public async Task<ActionResult> Create(RutaViewModel rutaViewModel)
        {
            var ruta = new Ruta
            {
                Origen = rutaViewModel.Origen,
                Destino = rutaViewModel.Destino,
                Distancia = rutaViewModel.Distancia,
                Envio = new List<Envio>() // Aquí necesitarías gestionar la relación con Envio
            };

            await _rutaRepository.AddAsync(ruta);
            return CreatedAtAction(nameof(GetById), new { id = ruta.Id }, rutaViewModel);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, RutaViewModel rutaViewModel)
        {
            if (id != rutaViewModel.Id) return BadRequest();

            var ruta = new Ruta
            {
                Id = rutaViewModel.Id,
                Origen = rutaViewModel.Origen,
                Destino = rutaViewModel.Destino,
                Distancia = rutaViewModel.Distancia,
                Envio = new List<Envio>() // Aquí necesitarías gestionar la relación con Envio
            };

            await _rutaRepository.UpdateAsync(ruta);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _rutaRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}