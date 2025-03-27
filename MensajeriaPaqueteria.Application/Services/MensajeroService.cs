using MensajeriaPaqueteria.Application.Contract;
using MensajeriaPaqueteria.Application.Core;
using MensajeriaPaqueteria.Application.Dtos;
using MensajeriaPaqueteria.Domain.Entities;
using MensajeriaPaqueteria.Infrastructure.Repositories.MensajeroR;

namespace MensajeriaPaqueteria.Application.Services
{

    public class MensajeroService(IMensajeroRepository repository) : BaseService, IMensajeroService
    {
        private readonly IMensajeroRepository _repository = repository;

        public async Task<IEnumerable<MensajeroDto>> GetAllAsync()
        {
            var mensajeros = await _repository.GetAllAsync();

            return mensajeros.Select(m => new MensajeroDto
            {
                MensajeroId = m.MensajeroId,
                Nombre = m.Nombre,
                Telefono = m.Telefono,
                Vehiculo = m.Vehiculo,
                Estado = m.Estado
            });
        }

        public async Task<MensajeroDto?> GetByIdAsync(int id)
        {
            var mensajero = await _repository.GetByIdAsync(id);

            if (mensajero == null)
                return null;

            return new MensajeroDto
            {
                MensajeroId = mensajero.MensajeroId,
                Nombre = mensajero.Nombre,
                Telefono = mensajero.Telefono,
                Vehiculo = mensajero.Vehiculo,
                Estado = mensajero.Estado
            };
        }

        public async Task<ServiceResult> CreateAsync(MensajeroDto mensajeroDto)
        {
            try
            {
                var mensajero = new Mensajero
                {
                    Nombre = mensajeroDto.Nombre,
                    Telefono = mensajeroDto.Telefono,
                    Vehiculo = mensajeroDto.Vehiculo,
                    Estado = mensajeroDto.Estado
                };

                await _repository.AddAsync(mensajero);

                return ServiceResult.Success("Mensajero creado exitosamente.");
            }
            catch (Exception ex)
            {
                return ServiceResult.Failure($"Error al crear el mensajero: {ex.Message}");
            }
        }

        public async Task<ServiceResult> UpdateAsync(int id, MensajeroDto mensajeroDto)
        {
            try
            {
                var existingMensajero = await _repository.GetByIdAsync(id);

                if (existingMensajero == null)
                    return ServiceResult.Failure($"Mensajero con ID {id} no encontrado.");

                existingMensajero.Nombre = mensajeroDto.Nombre;
                existingMensajero.Telefono = mensajeroDto.Telefono;
                existingMensajero.Vehiculo = mensajeroDto.Vehiculo;
                existingMensajero.Estado = mensajeroDto.Estado;

                await _repository.UpdateAsync(existingMensajero);

                return ServiceResult.Success("Mensajero actualizado exitosamente.");
            }
            catch (Exception ex)
            {
                return ServiceResult.Failure($"Error al actualizar el mensajero: {ex.Message}");
            }
        }

        public async Task<ServiceResult> DeleteAsync(int id)
        {
            try
            {
                var mensajero = await _repository.GetByIdAsync(id);

                if (mensajero == null)
                    return ServiceResult.Failure($"Mensajero con ID {id} no encontrado.");

                await _repository.DeleteAsync(id);

                return ServiceResult.Success("Mensajero eliminado exitosamente.");
            }
            catch (Exception ex)
            {
                return ServiceResult.Failure($"Error al eliminar el mensajero: {ex.Message}");
            }
        }
    }
}
