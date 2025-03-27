using MensajeriaPaqueteria.Domain.Entities;
using MensajeriaPaqueteria.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MensajeriaPaqueteria.Infrastructure.Repositories.EnvioR
{
    public class EnvioRepository : IEnvioRepository
    {
        private readonly MensajeriaPaqueteriaDbContext _context;

        public EnvioRepository(MensajeriaPaqueteriaDbContext context)
        {
            _context = context;
        }

        // Obtener todos los envíos
        public async Task<IEnumerable<Envio>> GetAllAsync()
        {
            return await _context.Envios
                .Include(e => e.Paquete) 
                .ToListAsync();
        }

        // Obtener un envío por su ID
        public async Task<Envio?> GetByIdAsync(int id)
        {
            return await _context.Envios
                .Include(e => e.Paquete) 
                .FirstOrDefaultAsync(e => e.EnvioId == id);
        }

        // Agregar un nuevo envío
        public async Task AddAsync(Envio envio)
        {
            await _context.Envios.AddAsync(envio);
            await _context.SaveChangesAsync();
        }

        // Actualizar un envío existente
        public async Task UpdateAsync(Envio envio)
        {
            _context.Envios.Update(envio);
            await _context.SaveChangesAsync();
        }

        // Eliminar un envío por su ID
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



