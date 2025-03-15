
using MensajeriaPaqueteria.Domain.Entities;
using MensajeriaPaqueteria.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MensajeriaPaqueteria.Infrastructure.Repositories.PaqueteR
{
    public class PaqueteRepository(MensajeriaPaqueteriaDbContext context) : IPaqueteRepository
    {
        private readonly MensajeriaPaqueteriaDbContext _context = context;

        public async Task<IEnumerable<Paquete>> GetAllAsync()
        {
            return await _context.Paquete.ToListAsync();
        }

        public async Task<Paquete?> GetByIdAsync(int id)
        {
            return await _context.Paquete
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task AddAsync(Paquete paquete)
        {
            await _context.Paquete.AddAsync(paquete);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Paquete paquete)
        {
            _context.Paquete.Update(paquete);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var paquete = await _context.Paquete.FindAsync(id);
            if (paquete != null)
            {
                _context.Paquete.Remove(paquete);
                await _context.SaveChangesAsync();
            }
        }
    }
}
