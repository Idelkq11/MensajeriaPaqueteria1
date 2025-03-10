using MensajeriaPaqueteria.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MensajeriaPaqueteria.Infrastructure.Repositories.EmpleadoR
{
    public interface IEmpleadoRepository
    {
        Task<IEnumerable<Empleado>> GetAllAsync();
        Task<Empleado?> GetByIdAsync(int id);
        Task AddAsync(Empleado empleado);
        Task UpdateAsync(Empleado empleado);
        Task DeleteAsync(int id);
    }
}

