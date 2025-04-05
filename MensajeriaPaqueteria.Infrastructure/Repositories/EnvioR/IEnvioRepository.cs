namespace MensajeriaPaqueteria.Infrastructure.Repositories.EnvioR
{
    using MensajeriaPaqueteria.Domain.Entities;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IEnvioRepository
    {
        Task<IEnumerable<Envio>> GetAllAsync();
        Task<Envio?> GetByIdAsync(int id);
        Task AddAsync(Envio envio);
        Task UpdateAsync(Envio envio);
        Task DeleteAsync(int id);

        // ✅ Actualizar la ubicación del envío en tiempo real
        Task ActualizarUbicacionAsync(int id, string nuevaUbicacion);

        // ✅ Actualizar el estado del envío (Pendiente, En camino, Entregado)
        Task CambiarEstadoAsync(int id, string nuevoEstado);

        // ✅ Guardar la firma de entrega en Base64
        Task SaveFirmaEntregaAsync(int id, string firmaBase64);

        // ✅ Confirmar entrega con firma
        Task ConfirmarEntregaAsync(int id, string firmaBase64);
        Task SaveChangesAsync();
    }
}
