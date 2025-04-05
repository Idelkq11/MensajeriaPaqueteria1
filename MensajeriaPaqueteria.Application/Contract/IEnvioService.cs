using MensajeriaPaqueteria.Application.Core;
using MensajeriaPaqueteria.Application.Dtos;

public interface IEnvioService
{
    Task<IEnumerable<EnvioDto>> GetAllAsync();
    Task<EnvioDto> GetByIdAsync(int id);
    Task<ServiceResult> CreateAsync(EnvioDto envioDto);
    Task<ServiceResult> UpdateAsync(int id, EnvioDto envioDto); // ✅ la que usaremos
    Task<ServiceResult> DeleteAsync(int id);
    Task<ServiceResult> ActualizarUbicacionAsync(int id, string ubicacionActual);
    Task<ServiceResult> CambiarEstadoAsync(int id, string estado);
    Task<ServiceResult> ConfirmarEntregaAsync(int id, string firmaBase64);
    Task AsignarMensajeroAsync(int id, string mensajero);
}
