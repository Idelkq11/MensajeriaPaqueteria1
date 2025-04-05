namespace MensajeriaPaqueteria.Infrastructure.Repositories.EnvioR
{
    using MensajeriaPaqueteria.Domain.Entities;
    using MensajeriaPaqueteria.Infrastructure.Data;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class EnvioRepository : IEnvioRepository
    {
        private readonly MensajeriaPaqueteriaDbContext _context;

        public EnvioRepository(MensajeriaPaqueteriaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Envio>> GetAllAsync()
        {
            return await _context.Envios
                .Include(e => e.Paquete)
                .ToListAsync();
        }

        public async Task<Envio?> GetByIdAsync(int id)
        {
            return await _context.Envios
                .Include(e => e.Paquete)
                .FirstOrDefaultAsync(e => e.EnvioId == id);
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

        // ✅ Actualiza la ubicación en tiempo real
        public async Task ActualizarUbicacionAsync(int envioId, string nuevaUbicacion)
        {
            var envio = await _context.Envios.FindAsync(envioId);
            if (envio != null)
            {
                envio.UbicacionActual = nuevaUbicacion;
                await _context.SaveChangesAsync();
            }
        }

        // ✅ Actualiza el estado del envío
        public async Task CambiarEstadoAsync(int envioId, string nuevoEstado)
        {
            var envio = await _context.Envios.FindAsync(envioId);
            if (envio != null)
            {
                envio.Estado = nuevoEstado;
                await _context.SaveChangesAsync();
            }
        }

        // ✅ Guarda la firma de entrega en Base64
        public async Task SaveFirmaEntregaAsync(int id, string firmaBase64)
        {
            var envio = await _context.Envios.FindAsync(id);
            if (envio != null)
            {
                envio.FirmaEntrega = firmaBase64;
                await _context.SaveChangesAsync();
            }
        }

        // ✅ Confirmar entrega y actualizar el estado
        public async Task ConfirmarEntregaAsync(int id, string firmaBase64)
        {
            var envio = await _context.Envios.FindAsync(id);
            if (envio != null)
            {
                // Actualizamos el estado del envío a "Entregado"
                envio.Estado = "Entregado";

                // Guardamos la firma de entrega
                envio.FirmaEntrega = firmaBase64;

                // Guardamos los cambios
                await _context.SaveChangesAsync();
            }
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}