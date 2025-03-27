using MensajeriaPaqueteria.Application.Contract;
using MensajeriaPaqueteria.Application.Core;
using MensajeriaPaqueteria.Application.Dtos;
using MensajeriaPaqueteria.Domain.Entities;
using MensajeriaPaqueteria.Infrastructure.Repositories.RutaR;

namespace MensajeriaPaqueteria.Application.Services
{

    public class RutaService : BaseService, IRutaService
    {
        private readonly IRutaRepository _repository;

        public RutaService(IRutaRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<RutaDto>> GetAllAsync()
        {
            var rutas = await _repository.GetAllAsync();

            return rutas.Select(r => new RutaDto
            {
                RutaId = r.RutaId,
                Origen = r.Origen,
                Destino = r.Destino,
                EstadoRuta = r.EstadoRuta,
                MensajeroId = r.MensajeroId,
                MensajeroNombre = r.Mensajero?.Nombre ?? "Sin nombre"  
            });
        }

        public async Task<RutaDto?> GetByIdAsync(int id)
        {
            var ruta = await _repository.GetByIdAsync(id);

            if (ruta == null)
                return null;

            return new RutaDto
            {
                RutaId = ruta.RutaId,
                Origen = ruta.Origen,
                Destino = ruta.Destino,
                EstadoRuta = ruta.EstadoRuta,
                MensajeroId = ruta.MensajeroId,
                MensajeroNombre = ruta.Mensajero?.Nombre ?? "Sin nombre" 
            };
        }

        public async Task<ServiceResult> CreateAsync(RutaDto rutaDto)
        {
            try
            {
                var ruta = new Ruta
                {
                    Origen = rutaDto.Origen,
                    Destino = rutaDto.Destino,
                    EstadoRuta = rutaDto.EstadoRuta,
                    MensajeroId = rutaDto.MensajeroId
                };

                await _repository.AddAsync(ruta);

                return ServiceResult.Success("Ruta creada exitosamente.");
            }
            catch (Exception ex)
            {
                return ServiceResult.Failure($"Error al crear la ruta: {ex.Message}");
            }
        }

        public async Task<ServiceResult> UpdateAsync(int id, RutaDto rutaDto)
        {
            try
            {
                var existingRuta = await _repository.GetByIdAsync(id);

                if (existingRuta == null)
                    return ServiceResult.Failure($"Ruta con ID {id} no encontrada.");

                existingRuta.Origen = rutaDto.Origen;
                existingRuta.Destino = rutaDto.Destino;
                existingRuta.EstadoRuta = rutaDto.EstadoRuta;
                existingRuta.MensajeroId = rutaDto.MensajeroId;

                await _repository.UpdateAsync(existingRuta);

                return ServiceResult.Success("Ruta actualizada exitosamente.");
            }
            catch (Exception ex)
            {
                return ServiceResult.Failure($"Error al actualizar la ruta: {ex.Message}");
            }
        }

        public async Task<ServiceResult> DeleteAsync(int id)
        {
            try
            {
                var ruta = await _repository.GetByIdAsync(id);

                if (ruta == null)
                    return ServiceResult.Failure($"Ruta con ID {id} no encontrada.");

                await _repository.DeleteAsync(id);

                return ServiceResult.Success("Ruta eliminada exitosamente.");
            }
            catch (Exception ex)
            {
                return ServiceResult.Failure($"Error al eliminar la ruta: {ex.Message}");
            }
        }
    }
}

