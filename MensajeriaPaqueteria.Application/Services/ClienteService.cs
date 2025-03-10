using MensajeriaPaqueteria.Domain.Entities;
using MensajeriaPaqueteria.Infrastructure.Repositories.ClienteR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MensajeriaPaqueteria.Application.Services
{
    public class ClienteService(IClienteRepository clienteRepository) : IClienteService
    {
        private readonly IClienteRepository _clienteRepository = clienteRepository;

        public async Task<IEnumerable<Cliente>> GetAllAsync()
        {
            return await _clienteRepository.GetAllAsync();
        }

        public async Task<Cliente?> GetByIdAsync(int id)
        {
            return await _clienteRepository.GetByIdAsync(id);
        }

        public async Task<string> CreateAsync(Cliente cliente)
        {
            try
            {
                await _clienteRepository.AddAsync(cliente);
                return "Cliente creado exitosamente.";
            }
            catch (Exception ex)
            {
                return $"Error al crear el cliente: {ex.Message}";
            }
        }

        public async Task<string> UpdateAsync(int id, Cliente cliente)
        {
            try
            {
                var existingCliente = await _clienteRepository.GetByIdAsync(id);

                if (existingCliente == null)
                    return $"Cliente con ID {id} no encontrado.";

                existingCliente.Nombre = cliente.Nombre;
                existingCliente.Direccion = cliente.Direccion;

                await _clienteRepository.UpdateAsync(existingCliente);

                return "Cliente actualizado exitosamente.";
            }
            catch (Exception ex)
            {
                return $"Error al actualizar el cliente: {ex.Message}";
            }
        }

        public async Task<string> DeleteAsync(int id)
        {
            try
            {
                var cliente = await _clienteRepository.GetByIdAsync(id);

                if (cliente == null)
                    return $"Cliente con ID {id} no encontrado.";

                await _clienteRepository.DeleteAsync(id);
                return "Cliente eliminado exitosamente.";
            }
            catch (Exception ex)
            {
                return $"Error al eliminar el cliente: {ex.Message}";
            }
        }
    }

    public interface IClienteService
    {
        Task<IEnumerable<Cliente>> GetAllAsync();
        Task<Cliente?> GetByIdAsync(int id);
        Task<string> CreateAsync(Cliente cliente);
        Task<string> UpdateAsync(int id, Cliente cliente);
        Task<string> DeleteAsync(int id);
    }
}
