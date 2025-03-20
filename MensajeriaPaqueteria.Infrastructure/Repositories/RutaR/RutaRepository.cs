using MensajeriaPaqueteria.Domain.Entities;
using MensajeriaPaqueteria.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MensajeriaPaqueteria.Infrastructure.Repositories.RutaR
{
    public class RutaRepository(MensajeriaPaqueteriaDbContext context) : IRutaRepository
    {
        private readonly MensajeriaPaqueteriaDbContext _context = context;

        public async Task<IEnumerable<Ruta>> GetAllAsync()
        {
            return await _context.Rutas.ToListAsync();
        }

        public async Task<Ruta?> GetByIdAsync(int id)
        {
            return await _context.Rutas
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task AddAsync(Ruta ruta)
        {
            await _context.Rutas.AddAsync(ruta);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Ruta ruta)
        {
            _context.Rutas.Update(ruta);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var ruta = await _context.Rutas.FindAsync(id);
            if (ruta != null)
            {
                _context.Rutas.Remove(ruta);
                await _context.SaveChangesAsync();
            }
        }
    }
}

