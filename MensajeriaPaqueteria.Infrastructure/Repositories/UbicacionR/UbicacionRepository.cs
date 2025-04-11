using MensajeriaPaqueteria.Domain.Entities;
using MensajeriaPaqueteria.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;

public class UbicacionRepository : IUbicacionRepository
{
    private readonly MensajeriaPaqueteriaDbContext _context;

    public UbicacionRepository(MensajeriaPaqueteriaDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Ubicacion ubicacion)
    {
        _context.Ubicaciones.Add(ubicacion);
        await _context.SaveChangesAsync();
    }

    public Task GetByMensajeroIdAsync(int mensajeroId)
    {
        throw new NotImplementedException();
    }

    public async Task<Ubicacion?> GetUltimaUbicacionAsync(int mensajeroId)
    {
        return await _context.Ubicaciones
            .Where(u => u.MensajeroId == mensajeroId)
            .OrderByDescending(u => u.FechaHora)
            .FirstOrDefaultAsync();
    }
}
