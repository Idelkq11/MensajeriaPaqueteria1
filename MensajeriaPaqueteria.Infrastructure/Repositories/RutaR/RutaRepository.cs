using MensajeriaPaqueteria.Domain.Entities;
using MensajeriaPaqueteria.Infrastructure.Data; // Asegúrate de que este espacio de nombres sea correcto
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MensajeriaPaqueteria.Infrastructure.Repositories.RutaR
{
    public class RutaRepository : IRutaRepository
    {
        private readonly MensajeriaPaqueteriaDbContext _context;

        public RutaRepository(MensajeriaPaqueteriaDbContext context)
        {
            _context = context;
        }

        // Obtener todas las rutas
        public async Task<IEnumerable<Ruta>> GetAllAsync()
        {
            return await _context.Rutas
                .Include(r => r.Mensajero) // Incluye la relación con Mensajero
                .ToListAsync();
        }

        // Obtener una ruta por su ID
        public async Task<Ruta?> GetByIdAsync(int id)
        {
            return await _context.Rutas
                .Include(r => r.Mensajero) // Incluye la relación con Mensajero
                .FirstOrDefaultAsync(r => r.RutaId == id);
        }

        // Agregar una nueva ruta
        public async Task AddAsync(Ruta ruta)
        {
            await _context.Rutas.AddAsync(ruta);
            await _context.SaveChangesAsync();
        }

        // Actualizar una ruta existente
        public async Task UpdateAsync(Ruta ruta)
        {
            _context.Rutas.Update(ruta);
            await _context.SaveChangesAsync();
        }

        // Eliminar una ruta por su ID
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
