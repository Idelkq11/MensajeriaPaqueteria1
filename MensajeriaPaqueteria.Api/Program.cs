using MensajeriaPaqueteria.Application.Services;
using MensajeriaPaqueteria.Infrastructure.Data;
using MensajeriaPaqueteria.Infrastructure.Repositories.ClienteR;
using MensajeriaPaqueteria.Infrastructure.Repositories.EmpleadoR;
using MensajeriaPaqueteria.Infrastructure.Repositories.EnvioR;
using MensajeriaPaqueteria.Infrastructure.Repositories.PaqueteR;
using MensajeriaPaqueteria.Infrastructure.Repositories.RutaR;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Registrar DbContext con la cadena de conexión
        builder.Services.AddDbContext<MensajeriaPaqueteriaDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("MensajeriaPaqueteriaDbs")));

        // Registrar Repositorios
        builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
        builder.Services.AddScoped<IEmpleadoRepository, EmpleadoRepository>();
        builder.Services.AddScoped<IRutaRepository, RutaRepository>(); // Asegúrate de que esta interfaz esté bien definida
        builder.Services.AddScoped<IPaqueteRepository, PaqueteRepository>();  // Correcto
        builder.Services.AddScoped<IEnvioRepository, EnvioRepository>();

        // Registrar Servicios
        builder.Services.AddScoped<IClienteService, ClienteService>();
        builder.Services.AddScoped<IEmpleadoService, EmpleadoService>();
        builder.Services.AddScoped<IRutaRepository, RutaRepository>(); // Asegúrate de que esta línea sea correcta para tu proyecto
        builder.Services.AddScoped<IPaqueteService, PaqueteService>();
        builder.Services.AddScoped<IEnvioService, EnvioService>();

        // Agregar controladores
        builder.Services.AddControllers();

        // Configuración de CORS
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAll", policy =>
                policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
        });

        // Habilitar Swagger
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configuración del pipeline HTTP
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.UseCors("AllowAll");

        app.MapControllers();
        app.Run();
    }
}