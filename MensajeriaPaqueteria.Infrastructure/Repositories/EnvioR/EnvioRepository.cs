using MensajeriaPaqueteria.Domain.Entities;
using MensajeriaPaqueteria.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MensajeriaPaqueteria.Infrastructure.Repositories.EnvioR
{
    public class EnvioRepository(MensajeriaPaqueteriaDbContext context) : IEnvioRepository
    {
        private readonly MensajeriaPaqueteriaDbContext _context = context;

        public async Task<IEnumerable<Envio>> GetAllAsync()
        {
            return await _context.Envios
                .Include(e => e.Paquete) // Incluye los datos del Paquete relacionado
                .ToListAsync();
        }

        public async Task<Envio?> GetByIdAsync(int id)
        {
            return await _context.Envios
                .Include(e => e.Paquete) // Incluye el Paquete relacionado
                
                .FirstOrDefaultAsync(e => e.Id == id); // Ejecuta la consulta
        }


        public async Task AddAsync(Envio envio)
        {
            await _context.Envios.AddAsync(envio);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Envio envio)
        {
            _context.Envios.Update(envio);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var envio = await _context.Envios.FindAsync(id);
            if (envio != null)
            {
                _context.Envios.Remove(envio);
                await _context.SaveChangesAsync();
            }
        }
    }
}


