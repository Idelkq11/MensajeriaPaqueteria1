using MensajeriaPaqueteria.Application.Contract;
using MensajeriaPaqueteria.Application.Core;
using MensajeriaPaqueteria.Application.Dtos;
using MensajeriaPaqueteria.Domain.Entities;
using MensajeriaPaqueteria.Infrastructure.Repositories.PaqueteR;

namespace MensajeriaPaqueteria.Application.Services
{

    public class PaqueteService : BaseService, IPaqueteService
    {
        private readonly IPaqueteRepository _repository;

        public PaqueteService(IPaqueteRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<PaqueteDto>> GetAllAsync()
        {
            var paquetes = await _repository.GetAllAsync();

            return paquetes.Select(p => new PaqueteDto
            {
                PaqueteId = p.PaqueteId,
                TipoPaquete = p.TipoPaquete,
                Peso = p.Peso,
                EstadoPaquete = p.EstadoPaquete,
                FechaEnvio = p.FechaEnvio,
                ClienteId = p.ClienteId,
               
            });
        }

        public async Task<PaqueteDto?> GetByIdAsync(int id)
        {
            var paquete = await _repository.GetByIdAsync(id);

            if (paquete == null)
                return null;

            return new PaqueteDto
            {
                PaqueteId = paquete.PaqueteId,
                TipoPaquete = paquete.TipoPaquete,
                Peso = paquete.Peso,
                EstadoPaquete = paquete.EstadoPaquete,
                FechaEnvio = paquete.FechaEnvio,
                ClienteId = paquete.ClienteId,
             
            };
        }

        public async Task<ServiceResult> CreateAsync(PaqueteDto paqueteDto)
        {
            try
            {
                var paquete = new Paquete
                {
                    TipoPaquete = paqueteDto.TipoPaquete,
                    Peso = paqueteDto.Peso,
                    EstadoPaquete = paqueteDto.EstadoPaquete,
                    FechaEnvio = paqueteDto.FechaEnvio,
                    ClienteId = paqueteDto.ClienteId
                };

                await _repository.AddAsync(paquete);

                return ServiceResult.Success("Paquete creado exitosamente.");
            }
            catch (Exception ex)
            {
                return ServiceResult.Failure($"Error al crear el paquete: {ex.Message}");
            }
        }

        public async Task<ServiceResult> UpdateAsync(int id, PaqueteDto paqueteDto)
        {
            try
            {
                var existingPaquete = await _repository.GetByIdAsync(id);

                if (existingPaquete == null)
                    return ServiceResult.Failure($"Paquete con ID {id} no encontrado.");

                existingPaquete.TipoPaquete = paqueteDto.TipoPaquete;
                existingPaquete.Peso = paqueteDto.Peso;
                existingPaquete.EstadoPaquete = paqueteDto.EstadoPaquete;
                existingPaquete.FechaEnvio = paqueteDto.FechaEnvio;
                existingPaquete.ClienteId = paqueteDto.ClienteId;

                await _repository.UpdateAsync(existingPaquete);

                return ServiceResult.Success("Paquete actualizado exitosamente.");
            }
            catch (Exception ex)
            {
                return ServiceResult.Failure($"Error al actualizar el paquete: {ex.Message}");
            }
        }

        public async Task<ServiceResult> DeleteAsync(int id)
        {
            try
            {
                var paquete = await _repository.GetByIdAsync(id);

                if (paquete == null)
                    return ServiceResult.Failure($"Paquete con ID {id} no encontrado.");

                await _repository.DeleteAsync(id);

                return ServiceResult.Success("Paquete eliminado exitosamente.");
            }
            catch (Exception ex)
            {
                return ServiceResult.Failure($"Error al eliminar el paquete: {ex.Message}");
            }
        }

        public Task UpdateAsync(PaqueteDto existingPaquete)
        {
            throw new NotImplementedException();
        }
    }
}
