using MensajeriaPaqueteria.Domain.Entities;

public class UbicacionService : IUbicacionService
{
    private readonly IUbicacionRepository _ubicacionRepository;

    public UbicacionService(IUbicacionRepository ubicacionRepository)
    {
        _ubicacionRepository = ubicacionRepository;
    }

    public async Task ActualizarUbicacionAsync(UbicacionDto dto)
    {
        var ubicacion = new Ubicacion
        {
            MensajeroId = dto.MensajeroId,
            Latitud = dto.Latitud,
            Longitud = dto.Longitud,
            FechaHora = DateTime.Now
        };

        await _ubicacionRepository.AddAsync(ubicacion);
    }

    public async Task<Ubicacion?> ObtenerUltimaUbicacionAsync(int mensajeroId)
    {
        return await _ubicacionRepository.GetUltimaUbicacionAsync(mensajeroId);
    }
}
