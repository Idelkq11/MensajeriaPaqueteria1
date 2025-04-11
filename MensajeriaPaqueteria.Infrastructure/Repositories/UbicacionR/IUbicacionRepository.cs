using MensajeriaPaqueteria.Domain.Entities;

public interface IUbicacionRepository
{
    Task AddAsync(Ubicacion ubicacion);
    Task GetByMensajeroIdAsync(int mensajeroId);
    Task<Ubicacion?> GetUltimaUbicacionAsync(int mensajeroId);
}
