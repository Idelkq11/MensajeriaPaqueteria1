using MensajeriaPaqueteria.Application.Contract;
using MensajeriaPaqueteria.Application.Core;
using MensajeriaPaqueteria.Application.Dtos;
using MensajeriaPaqueteria.Domain.Entities;
using MensajeriaPaqueteria.Infrastructure.Repositories.EnvioR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                PaqueteTipo = e.Paquete?.TipoPaquete ?? "Desconocido",
                UbicacionActual = e.UbicacionActual,
                Estado = e.Estado,
                FirmaEntrega = e.FirmaEntrega
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
                PaqueteTipo = envio.Paquete?.TipoPaquete ?? "Desconocido",
                UbicacionActual = envio.UbicacionActual,
                Estado = envio.Estado,
                FirmaEntrega = envio.FirmaEntrega
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
                    PaqueteId = envioDto.PaqueteId,
                    Estado = "Pendiente"
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

        public async Task<ServiceResult> ActualizarUbicacionAsync(int envioId, string nuevaUbicacion)
        {
            try
            {
                await _repository.ActualizarUbicacionAsync(envioId, nuevaUbicacion);
                return ServiceResult.Success("Ubicación actualizada exitosamente.");
            }
            catch (Exception ex)
            {
                return ServiceResult.Failure($"Error al actualizar la ubicación: {ex.Message}");
            }
        }

        public async Task<ServiceResult> CambiarEstadoAsync(int envioId, string nuevoEstado)
        {
            try
            {
                var envio = await _repository.GetByIdAsync(envioId);

                if (envio == null)
                    return ServiceResult.Failure($"Envío con ID {envioId} no encontrado.");

                envio.Estado = nuevoEstado;

                await _repository.UpdateAsync(envio);
                await _repository.SaveChangesAsync();

                return ServiceResult.Success("Estado del envío actualizado correctamente.");
            }
            catch (Exception ex)
            {
                return ServiceResult.Failure($"Error al actualizar el estado del envío: {ex.Message}");
            }
        }

        public async Task<ServiceResult> ConfirmarEntregaAsync(int envioId, string firmaBase64)
        {
            try
            {
                await _repository.ConfirmarEntregaAsync(envioId, firmaBase64);
                return ServiceResult.Success("Entrega confirmada exitosamente.");
            }
            catch (Exception ex)
            {
                return ServiceResult.Failure($"Error al confirmar la entrega: {ex.Message}");
            }
        }

        // ✅ Método opcional: para futuras mejoras
        public async Task AsignarMensajeroAsync(int id, string mensajero)
        {
            // Lógica pendiente de implementación
            // Podés agregar una propiedad "MensajeroAsignado" en la entidad si querés guardar esto.
            await Task.CompletedTask;
        }

        // ✅ Método opcional: Update sin ID separado (por si lo necesitás en otro contexto)
        public async Task UpdateAsync(EnvioDto envioDto)
        {
            var envio = await _repository.GetByIdAsync(envioDto.EnvioId);

            if (envio == null)
                return;

            envio.FechaEnvio = envioDto.FechaEnvio;
            envio.Direccion = envioDto.Direccion;
            envio.PaqueteId = envioDto.PaqueteId;
            envio.UbicacionActual = envioDto.UbicacionActual;
            envio.Estado = envioDto.Estado;
            envio.FirmaEntrega = envioDto.FirmaEntrega;

            await _repository.UpdateAsync(envio);
        }
    }
}
