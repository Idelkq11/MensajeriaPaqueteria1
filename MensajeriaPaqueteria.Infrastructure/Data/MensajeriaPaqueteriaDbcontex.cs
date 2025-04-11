using Microsoft.EntityFrameworkCore;
using MensajeriaPaqueteria.Domain.Entities;

namespace MensajeriaPaqueteria.Infrastructure.Data
{
    public class MensajeriaPaqueteriaDbContext : DbContext
    {
        public MensajeriaPaqueteriaDbContext(DbContextOptions<MensajeriaPaqueteriaDbContext> options)
            : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Paquete> Paquetes { get; set; }
        public DbSet<Envio> Envios { get; set; }
        public DbSet<Mensajero>  Mensajeros { get; set; }
        public DbSet<Ruta> Rutas { get; set; }
        public DbSet<Ubicacion> Ubicaciones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relación Envio - Paquete
            modelBuilder.Entity<Envio>()
                .HasOne(e => e.Paquete)
                .WithMany()
                .HasForeignKey(e => e.PaqueteId)
                .HasPrincipalKey(p => p.PaqueteId);

            // Relación Paquete - Cliente
            modelBuilder.Entity<Paquete>()
                .HasOne(p => p.Cliente)
                .WithMany()
                .HasForeignKey(p => p.ClienteId)
                .HasPrincipalKey(c => c.ClienteId);

            // Relación Ruta - Mensajero
            modelBuilder.Entity<Ruta>()
                .HasOne(r => r.Mensajero)
                .WithMany()
                .HasForeignKey(r => r.MensajeroId)
                .HasPrincipalKey(m => m.MensajeroId);
                 
            base.OnModelCreating(modelBuilder);
        }
    }
}