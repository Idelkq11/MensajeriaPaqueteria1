using MensajeriaPaqueteria.Domain.Entities;
using MensajeriaPaqueteria.Infrastructure.Repositories.PaqueteR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MensajeriaPaqueteria.Application.Services
{
    public class PaqueteService(IPaqueteRepository paqueteRepository) : IPaqueteService
    {
        private readonly IPaqueteRepository _paqueteRepository = paqueteRepository;

        public async Task<IEnumerable<Paquete>> GetAllAsync()
        {
            return await _paqueteRepository.GetAllAsync();
        }

        public async Task<Paquete?> GetByIdAsync(int id)
        {
            return await _paqueteRepository.GetByIdAsync(id);
        }

        public async Task<string> CreateAsync(Paquete paquete)
        {
            try
            {
                await _paqueteRepository.AddAsync(paquete);
                return "Paquete creado exitosamente.";
            }
            catch (Exception ex)
            {
                return $"Error al crear el paquete: {ex.Message}";
            }
        }

        public async Task<string> UpdateAsync(int id, Paquete paquete)
        {
            try
            {
                var existingPaquete = await _paqueteRepository.GetByIdAsync(id);

                if (existingPaquete == null)
                    return $"Paquete con ID {id} no encontrado.";

                existingPaquete.Nombre = paquete.Nombre; // Actualiza el nombre
                existingPaquete.Peso = paquete.Peso; // Actualiza el peso
                existingPaquete.Descripcion = paquete.Descripcion; // Actualiza la descripción

                await _paqueteRepository.UpdateAsync(existingPaquete);

                return "Paquete actualizado exitosamente.";
            }
            catch (Exception ex)
            {
                return $"Error al actualizar el paquete: {ex.Message}";
            }
        }

        public async Task<string> DeleteAsync(int id)
        {
            try
            {
                var paquete = await _paqueteRepository.GetByIdAsync(id);

                if (paquete == null)
                    return $"Paquete con ID {id} no encontrado.";

                await _paqueteRepository.DeleteAsync(id);
                return "Paquete eliminado exitosamente.";
            }
            catch (Exception ex)
            {
                return $"Error al eliminar el paquete: {ex.Message}";
            }
        }
    }

    public interface IPaqueteService
    {
        Task<IEnumerable<Paquete>> GetAllAsync();
        Task<Paquete?> GetByIdAsync(int id);
        Task<string> CreateAsync(Paquete paquete);
        Task<string> UpdateAsync(int id, Paquete paquete);
        Task<string> DeleteAsync(int id);
    }
}
