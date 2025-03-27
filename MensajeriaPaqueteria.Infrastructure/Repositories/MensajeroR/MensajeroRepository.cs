using MensajeriaPaqueteria.Domain.Entities;
using MensajeriaPaqueteria.Infrastructure.Data; 
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MensajeriaPaqueteria.Infrastructure.Repositories.MensajeroR
{
    public class MensajeroRepository : IMensajeroRepository
    {
        private readonly MensajeriaPaqueteriaDbContext _context;

        public MensajeroRepository(MensajeriaPaqueteriaDbContext context)
        {
            _context = context;
        }

        // Obtener todos los mensajeros
        public async Task<IEnumerable<Mensajero>> GetAllAsync()
        {
            return await _context.Mensajeros.ToListAsync();
        }

        // Obtener un mensajero por su ID
        public async Task<Mensajero?> GetByIdAsync(int id)
        {
            return await _context.Mensajeros
                .FirstOrDefaultAsync(m => m.MensajeroId == id);
        }

        // Agregar un nuevo mensajero
        public async Task AddAsync(Mensajero mensajero)
        {
            await _context.Mensajeros.AddAsync(mensajero);
            await _context.SaveChangesAsync();
        }

        // Actualizar un mensajero existente
        public async Task UpdateAsync(Mensajero mensajero)
        {
            _context.Mensajeros.Update(mensajero);
            await _context.SaveChangesAsync();
        }

        // Eliminar un mensajero por su ID
        public async Task DeleteAsync(int id)
        {
            var mensajero = await _context.Mensajeros.FindAsync(id);
            if (mensajero != null)
            {
                _context.Mensajeros.Remove(mensajero);
                await _context.SaveChangesAsync();
            }
        }
    }
}
