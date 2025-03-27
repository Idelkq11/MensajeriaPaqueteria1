using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MensajeriaPaqueteria.Infrastructure.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MensajeriaPaqueteriaDbContext>
    {
        public MensajeriaPaqueteriaDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MensajeriaPaqueteriaDbContext>();
            optionsBuilder.UseSqlServer("Server=IDELKQ11\\SQLEXPRESS;Database=MensajeriaPaqueteriaDbs;Trusted_Connection=True;TrustServerCertificate=True;"); 

            return new MensajeriaPaqueteriaDbContext(optionsBuilder.Options);
        }
    }
}
