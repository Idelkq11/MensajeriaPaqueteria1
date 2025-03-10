using MensajeriaPaqueteria.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MensajeriaPaqueteria.Infrastructure.Repositories.RutaR
{
    public interface IRutaRepository
    {
        Task<IEnumerable<Ruta>> GetAllAsync();
        Task<Ruta?> GetByIdAsync(int id); // Se corrigió para permitir valores nulos
        Task AddAsync(Ruta ruta);
        Task UpdateAsync(Ruta ruta);
        Task DeleteAsync(int id);
    }
}

