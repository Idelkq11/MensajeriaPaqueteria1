namespace MensajeriaPaqueteria.Infrastructure.Repositories.ClienteR
{
    using MensajeriaPaqueteria.Domain.Entities;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IClienteRepository
    {
        Task<IEnumerable<Cliente>> GetAllAsync();
        Task<Cliente?> GetByIdAsync(int id);
        Task AddAsync(Cliente cliente);
        Task UpdateAsync(Cliente cliente);
        Task DeleteAsync(int id);
    }
}
