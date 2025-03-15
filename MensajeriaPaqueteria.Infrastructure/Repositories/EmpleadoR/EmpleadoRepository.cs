using MensajeriaPaqueteria.Domain.Entities;
using MensajeriaPaqueteria.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MensajeriaPaqueteria.Infrastructure.Repositories.EmpleadoR
{
    public class EmpleadoRepository(MensajeriaPaqueteriaDbContext context) : IEmpleadoRepository
    {
        private readonly MensajeriaPaqueteriaDbContext _context = context;

        public async Task<IEnumerable<Empleado>> GetAllAsync()
        {
            return await _context.Empleado.ToListAsync();
        }

        public async Task<Empleado?> GetByIdAsync(int id)
        {
            return await _context.Empleado.FindAsync(id);
        }

        public async Task AddAsync(Empleado empleado)
        {
            await _context.Empleado.AddAsync(empleado);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Empleado empleado)
        {
            _context.Empleado.Update(empleado);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var empleado = await _context.Empleado.FindAsync(id);
            if (empleado != null)
            {
                _context.Empleado.Remove(empleado);
                await _context.SaveChangesAsync();
            }
        }
    }
}
