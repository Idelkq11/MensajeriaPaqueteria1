using MensajeriaPaqueteria.Domain.Entities;
using MensajeriaPaqueteria.Infrastructure.Repositories.RutaR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MensajeriaPaqueteria.Application.Services
{
    public class RutaService(IRutaRepository rutaRepository) : RutaService.IRutaService
    {
        private readonly IRutaRepository _rutaRepository = rutaRepository;

        // Obtener todas las rutas
        public async Task<IEnumerable<Ruta>> GetAllAsync()
        {
            return await _rutaRepository.GetAllAsync();
        }

        // Obtener una ruta por ID
        public async Task<Ruta?> GetByIdAsync(int id)
        {
            return await _rutaRepository.GetByIdAsync(id);
        }

        // Crear una nueva ruta
        public async Task<string> CreateAsync(Ruta ruta)
        {
            try
            {
                // Llamamos al repositorio para agregar la nueva ruta
                await _rutaRepository.AddAsync(ruta);
                return "Ruta creada exitosamente.";
            }
            catch (Exception ex)
            {
                // Si ocurre un error, devolvemos el mensaje correspondiente
                return $"Error al crear la ruta: {ex.Message}";
            }
        }

        // Actualizar una ruta existente
        public async Task<string> UpdateAsync(int id, Ruta ruta)
        {
            try
            {
                // Verificamos si la ruta existe
                var existingRuta = await _rutaRepository.GetByIdAsync(id);

                if (existingRuta == null)
                    return $"Ruta con ID {id} no encontrada.";

                // Actualizamos los valores de la ruta
                existingRuta.Origen = ruta.Origen;
                existingRuta.Destino = ruta.Destino;
                existingRuta.Distancia = ruta.Distancia;

                // Llamamos al repositorio para actualizar la ruta
                await _rutaRepository.UpdateAsync(existingRuta);
                return "Ruta actualizada exitosamente.";
            }
            catch (Exception ex)
            {
                return $"Error al actualizar la ruta: {ex.Message}";
            }
        }

        // Eliminar una ruta
        public async Task<string> DeleteAsync(int id)
        {
            try
            {
                var ruta = await _rutaRepository.GetByIdAsync(id);

                if (ruta == null)
                    return $"Ruta con ID {id} no encontrada.";

                await _rutaRepository.DeleteAsync(id);
                return "Ruta eliminada exitosamente.";
            }
            catch (Exception ex)
            {
                return $"Error al eliminar la ruta: {ex.Message}";
            }
        }



        public interface IRutaService
        {
        }
    }
}




