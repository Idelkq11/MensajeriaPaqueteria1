using MensajeriaPaqueteria.Domain.Entities;
using MensajeriaPaqueteria.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MensajeriaPaqueteria.Infrastructure.Repositories.ClienteR
{
    public class ClienteRepository(MensajeriaPaqueteriaDbContext context) : IClienteRepository
    {
        private readonly MensajeriaPaqueteriaDbContext _context = context;

        public async Task<IEnumerable<Cliente>> GetAllAsync()
        {
            return await _context.Cliente.ToListAsync();
        }

        public async Task<Cliente?> GetByIdAsync(int id)
        {
            return await _context.Cliente
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task AddAsync(Cliente cliente)
        {
            await _context.Cliente.AddAsync(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Cliente cliente)
        {
            _context.Cliente.Update(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var cliente = await _context.Cliente.FindAsync(id);
            if (cliente != null)
            {
                _context.Cliente.Remove(cliente);
                await _context.SaveChangesAsync();
            }
        }
    }
}
