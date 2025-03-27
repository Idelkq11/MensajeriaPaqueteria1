using MensajeriaPaqueteria.Application.Contract;
using MensajeriaPaqueteria.Application.Core;
using MensajeriaPaqueteria.Application.Dtos;
using MensajeriaPaqueteria.Domain.Entities;
using MensajeriaPaqueteria.Infrastructure.Repositories.EnvioR;

namespace MensajeriaPaqueteria.Application.Services
{

    public class EnvioService : BaseService, IEnvioService
    {
        private readonly IEnvioRepository _repository;

        public EnvioService(IEnvioRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<EnvioDto>> GetAllAsync()
        {
            var envios = await _repository.GetAllAsync();

            return envios.Select(e => new EnvioDto
            {
                EnvioId = e.EnvioId,
                FechaEnvio = e.FechaEnvio,
                Direccion = e.Direccion,
                PaqueteId = e.PaqueteId,
                PaqueteTipo = e.Paquete?.TipoPaquete ?? "Desconocido"
            });
        }

        public async Task<EnvioDto?> GetByIdAsync(int id)
        {
            var envio = await _repository.GetByIdAsync(id);

            if (envio == null)
                return null;

            return new EnvioDto
            {
                EnvioId = envio.EnvioId,
                FechaEnvio = envio.FechaEnvio,
                Direccion = envio.Direccion,
                PaqueteId = envio.PaqueteId,
                PaqueteTipo = envio.Paquete?.TipoPaquete ?? "Desconocido"
            };
        }

        public async Task<ServiceResult> CreateAsync(EnvioDto envioDto)
        {
            try
            {
                var envio = new Envio
                {
                    FechaEnvio = envioDto.FechaEnvio,
                    Direccion = envioDto.Direccion,
                    PaqueteId = envioDto.PaqueteId
                };
                await _repository.AddAsync(envio);

                return ServiceResult.Success("Envío creado exitosamente.");
            }
            catch (Exception ex)
            {
                return ServiceResult.Failure($"Error al crear el envío: {ex.Message}");
            }
        }

        public async Task<ServiceResult> UpdateAsync(int id, EnvioDto envioDto)
        {
            try
            {
                var existingEnvio = await _repository.GetByIdAsync(id);

                if (existingEnvio == null)
                    return ServiceResult.Failure($"Envío con ID {id} no encontrado.");

                existingEnvio.FechaEnvio = envioDto.FechaEnvio;
                existingEnvio.Direccion = envioDto.Direccion;
                existingEnvio.PaqueteId = envioDto.PaqueteId;

                await _repository.UpdateAsync(existingEnvio);

                return ServiceResult.Success("Envío actualizado exitosamente.");
            }
            catch (Exception ex)
            {
                return ServiceResult.Failure($"Error al actualizar el envío: {ex.Message}");
            }
        }

        public async Task<ServiceResult> DeleteAsync(int id)
        {
            try
            {
                var envio = await _repository.GetByIdAsync(id);

                if (envio == null)
                    return ServiceResult.Failure($"Envío con ID {id} no encontrado.");

                await _repository.DeleteAsync(id);

                return ServiceResult.Success("Envío eliminado exitosamente.");
            }
            catch (Exception ex)
            {
                return ServiceResult.Failure($"Error al eliminar el envío: {ex.Message}");
            }
        }
    }
}
