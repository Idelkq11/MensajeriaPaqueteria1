using Microsoft.EntityFrameworkCore;
using MensajeriaPaqueteria.Domain.Entities;
using MensajeriaPaqueteria.Infrastructure.Data;


namespace MensajeriaPaqueteria.Infrastructure.Data
{
    public class MensajeriaPaqueteriaDbContext : DbContext // Corregido aquí: uso de ":" en lugar de "()"
    {
        public MensajeriaPaqueteriaDbContext(DbContextOptions<MensajeriaPaqueteriaDbContext> options) : base(options) { }

        public  DbSet<Cliente> Cliente { get; set; }
        public  DbSet<Empleado> Empleado { get; set; }
        public  DbSet<Envio> Envio { get; set; }
        public  DbSet<Ruta> Ruta { get; set; }
        public  DbSet<Paquete> Paquete  { get; set; }

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

            // Relación Envio - Paquete (1 Paquete puede estar en varios Envios)
            modelBuilder.Entity<Paquete>()
                .HasMany(p => p.Envio)  // Paquete tiene muchos envíos
                .WithOne(e => e.Paquete)  // Un Envio tiene un Paquete
                .HasForeignKey(e => e.PaqueteId)  // Clave foránea en Envio
                .OnDelete(DeleteBehavior.Restrict);


            // Relación Ruta - Empleado
            modelBuilder.Entity<Ruta>()
                .HasOne(r => r.Empleado)
                .WithMany()
                .HasForeignKey(r => r.EmpleadoId)
                .HasPrincipalKey(emp => emp.Id);


             modelBuilder.Entity<Cliente>()
             .HasMany(c => c.Paquete)
             .WithOne(p => p.Cliente)  // Paquete tiene una referencia a Cliente
             .HasForeignKey(p => p.ClienteId)  // Paquete tiene una propiedad ClienteId
             .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
} 

