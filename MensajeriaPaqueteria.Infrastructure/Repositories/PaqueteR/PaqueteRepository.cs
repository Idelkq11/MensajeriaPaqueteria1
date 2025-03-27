using MensajeriaPaqueteria.Domain.Entities;
using MensajeriaPaqueteria.Infrastructure.Data; // Asegúrate de que este espacio de nombres sea correcto
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MensajeriaPaqueteria.Infrastructure.Repositories.PaqueteR
{
    public class PaqueteRepository : IPaqueteRepository
    {
        private readonly MensajeriaPaqueteriaDbContext _context;

        public PaqueteRepository(MensajeriaPaqueteriaDbContext context)
        {
            _context = context;
        }

        // Obtener todos los paquetes
        public async Task<IEnumerable<Paquete>> GetAllAsync()
        {
            return await _context.Paquetes
                .Include(p => p.Cliente) // Incluye la relación con Cliente
                .ToListAsync();
        }

        // Obtener un paquete por su ID
        public async Task<Paquete?> GetByIdAsync(int id)
        {
            return await _context.Paquetes
                .Include(p => p.Cliente) // Incluye la relación con Cliente
                .FirstOrDefaultAsync(p => p.PaqueteId == id);
        }

        // Agregar un nuevo paquete
        public async Task AddAsync(Paquete paquete)
        {
            await _context.Paquetes.AddAsync(paquete);
            await _context.SaveChangesAsync();
        }

        // Actualizar un paquete existente
        public async Task UpdateAsync(Paquete paquete)
        {
            _context.Paquetes.Update(paquete);
            await _context.SaveChangesAsync();
        }

        // Eliminar un paquete por su ID
        public async Task DeleteAsync(int id)
        {
            var paquete = await _context.Paquetes.FindAsync(id);
            if (paquete != null)
            {
                _context.Paquetes.Remove(paquete);
                await _context.SaveChangesAsync();
            }
        }
    }
}
