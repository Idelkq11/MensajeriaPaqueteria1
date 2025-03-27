using MensajeriaPaqueteria.Application.Contract;
using MensajeriaPaqueteria.Application.Dtos;
using MensajeriaPaqueteria.Application.Core;
using MensajeriaPaqueteria.Domain.Entities;
using MensajeriaPaqueteria.Infrastructure.Repositories.ClienteR;

namespace MensajeriaPaqueteria.Application.Services
{

    public class ClienteService : BaseService, IClienteService
    {
        private readonly IClienteRepository _repository;

        public ClienteService(IClienteRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ClienteDto>> GetAllAsync()
        {
            var clientes = await _repository.GetAllAsync();
            return clientes.Select(c => new ClienteDto
            {
                ClienteId = c.ClienteId,
                Nombre = c.Nombre,
                Direccion = c.Direccion,
                Telefono = c.Telefono
            });
        }

        public async Task<ClienteDto?> GetByIdAsync(int id)
        {
            var cliente = await _repository.GetByIdAsync(id);
            if (cliente == null) return null;

            return new ClienteDto
            {
                ClienteId = cliente.ClienteId,
                Nombre = cliente.Nombre,
                Direccion = cliente.Direccion,
                Telefono = cliente.Telefono
            };
        }

        public async Task<ServiceResult> CreateAsync(ClienteDto clienteDto)
        {
            try
            {
                var cliente = new Cliente
                {
                    Nombre = clienteDto.Nombre,
                    Direccion = clienteDto.Direccion,
                    Telefono = clienteDto.Telefono
                };

                await _repository.AddAsync(cliente);
                return ServiceResult.Success("Cliente creado exitosamente.");
            }
            catch (Exception ex)
            {
                return ServiceResult.Failure($"Error al crear el cliente: {ex.Message}");
            }
        }

        public async Task<ServiceResult> UpdateAsync(int id, ClienteDto clienteDto)
        {
            try
            {
                var cliente = await _repository.GetByIdAsync(id);
                if (cliente == null) return ServiceResult.Failure("Cliente no encontrado.");

                cliente.Nombre = clienteDto.Nombre;
                cliente.Direccion = clienteDto.Direccion;
                cliente.Telefono = clienteDto.Telefono;

                await _repository.UpdateAsync(cliente);
                return ServiceResult.Success("Cliente actualizado exitosamente.");
            }
            catch (Exception ex)
            {
                return ServiceResult.Failure($"Error al actualizar el cliente: {ex.Message}");
            }
        }

        public async Task<ServiceResult> DeleteAsync(int id)
        {
            try
            {
                var cliente = await _repository.GetByIdAsync(id);
                if (cliente == null) return ServiceResult.Failure("Cliente no encontrado.");

                await _repository.DeleteAsync(id);
                return ServiceResult.Success("Cliente eliminado exitosamente.");
            }
            catch (Exception ex)
            {
                return ServiceResult.Failure($"Error al eliminar el cliente: {ex.Message}");
            }
        }
    }
}

