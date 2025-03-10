namespace MensajeriaPaqueteria.Infrastructure.Repositories.EnvioR
{
    using MensajeriaPaqueteria.Domain.Entities;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IEnvioRepository
    {
        Task<IEnumerable<Envio>> GetAllAsync();
        Task<Envio> GetByIdAsync(int id);
        Task AddAsync(Envio envio);
        Task UpdateAsync(Envio envio);
        Task DeleteAsync(int id);
    }
}
