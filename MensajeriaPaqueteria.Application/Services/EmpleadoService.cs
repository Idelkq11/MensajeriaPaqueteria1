using MensajeriaPaqueteria.Domain.Entities;
using MensajeriaPaqueteria.Infrastructure.Repositories.EmpleadoR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MensajeriaPaqueteria.Application.Services
{
    public class EmpleadoService(IEmpleadoRepository empleadoRepository) : IEmpleadoService
    {
        private readonly IEmpleadoRepository _empleadoRepository = empleadoRepository;

        public async Task<IEnumerable<Empleado>> GetAllAsync()
        {
            return await _empleadoRepository.GetAllAsync();
        }

        public async Task<Empleado?> GetByIdAsync(int id)
        {
            return await _empleadoRepository.GetByIdAsync(id);
        }

        public async Task<string> CreateAsync(Empleado empleado)
        {
            try
            {
                await _empleadoRepository.AddAsync(empleado);
                return "Empleado creado exitosamente.";
            }
            catch (Exception ex)
            {
                return $"Error al crear el empleado: {ex.Message}";
            }
        }

        public async Task<string> UpdateAsync(int id, Empleado empleado)
        {
            try
            {
                var existingEmpleado = await _empleadoRepository.GetByIdAsync(id);

                if (existingEmpleado == null)
                    return $"Empleado con ID {id} no encontrado.";

                existingEmpleado.Nombre = empleado.Nombre;
                existingEmpleado.Cargo = empleado.Cargo;
                existingEmpleado.Telefono = empleado.Telefono;

                await _empleadoRepository.UpdateAsync(existingEmpleado);

                return "Empleado actualizado exitosamente.";
            }
            catch (Exception ex)
            {
                return $"Error al actualizar el empleado: {ex.Message}";
            }
        }

        public async Task<string> DeleteAsync(int id)
        {
            try
            {
                var empleado = await _empleadoRepository.GetByIdAsync(id);

                if (empleado == null)
                    return $"Empleado con ID {id} no encontrado.";

                await _empleadoRepository.DeleteAsync(id);
                return "Empleado eliminado exitosamente.";
            }
            catch (Exception ex)
            {
                return $"Error al eliminar el empleado: {ex.Message}";
            }
        }
    }

    public interface IEmpleadoService
    {
        Task<IEnumerable<Empleado>> GetAllAsync();
        Task<Empleado?> GetByIdAsync(int id);
        Task<string> CreateAsync(Empleado empleado);
        Task<string> UpdateAsync(int id, Empleado empleado);
        Task<string> DeleteAsync(int id);
    }
}
