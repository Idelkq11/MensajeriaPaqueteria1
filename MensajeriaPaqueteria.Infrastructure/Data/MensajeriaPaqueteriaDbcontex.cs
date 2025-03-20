using Microsoft.EntityFrameworkCore;
using MensajeriaPaqueteria.Domain.Entities;
using MensajeriaPaqueteria.Infrastructure.Data;


namespace MensajeriaPaqueteria.Infrastructure.Data
{
    public class MensajeriaPaqueteriaDbContext : DbContext 
    {
        public MensajeriaPaqueteriaDbContext(DbContextOptions<MensajeriaPaqueteriaDbContext> options) : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Envio> Envios { get; set; }
        public DbSet<Ruta> Rutas { get; set; }
        public DbSet<Paquete> Paquetes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relación Envio - Cliente
            modelBuilder.Entity<Envio>()
                .HasOne(e => e.Cliente)
                .WithMany()
                .HasForeignKey(e => e.ClienteId)
                .HasPrincipalKey(c => c.Id);

            // Relación Envio - Empleado
            modelBuilder.Entity<Envio>()
                .HasOne(e => e.Empleado)
                .WithMany()
                .HasForeignKey(e => e.EmpleadoId)
                .HasPrincipalKey(emp => emp.Id);


            base.OnModelCreating(modelBuilder);

        }
    }
}
