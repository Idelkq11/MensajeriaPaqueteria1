using MensajeriaPaqueteria.Domain.Entities;
using MensajeriaPaqueteria.Infrastructure.Repositories.EnvioR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MensajeriaPaqueteria.Application.Services
{
    public class EnvioService(IEnvioRepository envioRepository) : IEnvioService
    {
        private readonly IEnvioRepository _envioRepository = envioRepository;

        public async Task<IEnumerable<Envio>> GetAllAsync()
        {
            return await _envioRepository.GetAllAsync();
        }

        public async Task<Envio?> GetByIdAsync(int id)
        {
            return await _envioRepository.GetByIdAsync(id);
        }

        public async Task<string> CreateAsync(Envio envio)
        {
            try
            {
                await _envioRepository.AddAsync(envio);
                return "Envio creado exitosamente.";
            }
            catch (Exception ex)
            {
                return $"Error al crear el envio: {ex.Message}";
            }
        }

        public async Task<string> UpdateAsync(int id, Envio envio)
        {
            try
            {
                var existingEnvio = await _envioRepository.GetByIdAsync(id);

                if (existingEnvio == null)
                    return $"Envio con ID {id} no encontrado.";

                existingEnvio.PaqueteId = envio.PaqueteId;
                existingEnvio.FechaEnvio = envio.FechaEnvio;
                existingEnvio.FechaEntrega = envio.FechaEntrega;
                existingEnvio.Estado = envio.Estado;
                

                await _envioRepository.UpdateAsync(existingEnvio);

                return "Envio actualizado exitosamente.";
            }
            catch (Exception ex)
            {
                return $"Error al actualizar el envio: {ex.Message}";
            }
        }

        public async Task<string> DeleteAsync(int id)
        {
            try
            {
                var envio = await _envioRepository.GetByIdAsync(id);

                if (envio == null)
                    return $"Envio con ID {id} no encontrado.";

                await _envioRepository.DeleteAsync(id);
                return "Envio eliminado exitosamente.";
            }
            catch (Exception ex)
            {
                return $"Error al eliminar el envio: {ex.Message}";
            }
        }
    }

    public interface IEnvioService
    {
    }
}
