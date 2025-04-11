using MensajeriaPaqueteria.Domain.Entities;

public interface IUbicacionService
{
    Task ActualizarUbicacionAsync(UbicacionDto dto);
    Task<Ubicacion?> ObtenerUltimaUbicacionAsync(int mensajeroId);
}
