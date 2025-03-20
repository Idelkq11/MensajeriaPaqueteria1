using MensajeriaPaqueteria.Application.Services;
using MensajeriaPaqueteria.Infrastructure.Data;
using MensajeriaPaqueteria.Infrastructure.Repositories.ClienteR;
using MensajeriaPaqueteria.Infrastructure.Repositories.EmpleadoR;
using MensajeriaPaqueteria.Infrastructure.Repositories.EnvioR;
using MensajeriaPaqueteria.Infrastructure.Repositories.PaqueteR;
using MensajeriaPaqueteria.Infrastructure.Repositories.RutaR;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using MensajeriaPaqueteria.Api.Mappings;


    
        var builder = WebApplication.CreateBuilder(args);

       // Configuración de Swagger para la documentación de la API
       builder.Services.AddEndpointsApiExplorer();
       builder.Services.AddSwaggerGen();

      var Configuration = builder.Configuration;


// Registrar DbContext con la cadena de conexión
builder.Services.AddDbContext<MensajeriaPaqueteriaDbContext>(options =>
            options.UseSqlServer(
            Configuration.GetConnectionString("MensajeriaPaqueteriaDbs"),
             b => b.MigrationsAssembly("MensajeriaPaqueteria.Infrastructure.Data")
             ));

        // Registrar Repositorios
        builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
        builder.Services.AddScoped<IEmpleadoRepository, EmpleadoRepository>();
        builder.Services.AddScoped<IRutaRepository, RutaRepository>(); 
        builder.Services.AddScoped<IPaqueteRepository, PaqueteRepository>();  

        // Registrar Servicios
        builder.Services.AddScoped<IClienteService, ClienteService>();
        builder.Services.AddScoped<IEmpleadoService, EmpleadoService>();
        builder.Services.AddScoped<IRutaRepository, RutaRepository>(); 
        builder.Services.AddScoped<IPaqueteService, PaqueteService>();
        builder.Services.AddScoped<IEnvioService, EnvioService>();


// API permite solicitudes desde el proyecto web 
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Agregar controladores
builder.Services.AddControllers();

// Registro de AutoMapper y el perfil de mapeo
builder.Services.AddAutoMapper(typeof(MappingProfile));


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
    

