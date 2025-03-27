using MensajeriaPaqueteria.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace MensajeriaPaqueteria.Infrastructure.Repositories.MensajeroR
{
    
    public interface IMensajeroRepository
    {
        Task<IEnumerable<Mensajero>> GetAllAsync();
        Task<Mensajero?> GetByIdAsync(int id);
        Task AddAsync(Mensajero mensajero);
        Task UpdateAsync(Mensajero mensajero);
        Task DeleteAsync(int id);
    }
}