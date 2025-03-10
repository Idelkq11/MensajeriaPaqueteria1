using MensajeriaPaqueteria.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MensajeriaPaqueteria.Infrastructure.Repositories.PaqueteR
{
    public interface IPaqueteRepository
    {
        Task<IEnumerable<Paquete>> GetAllAsync();
        Task<Paquete?> GetByIdAsync(int id);
        Task AddAsync(Paquete paquete);
        Task UpdateAsync(Paquete paquete);
        Task DeleteAsync(int id);
    }
}

