using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MensajeriaPaqueteria.Infrastructure.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MensajeriaPaqueteriaDbContext>
    {
        public MensajeriaPaqueteriaDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MensajeriaPaqueteriaDbContext>();
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=MensajeriaPaqueteriaDbs;Trusted_Connection=True;TrustServerCertificate=True;"); // Usa tu cadena de conexión aquí

            return new MensajeriaPaqueteriaDbContext(optionsBuilder.Options);
        }
    }
}
