
using MensajeriaPaqueteria.Infrastructure.Data;
using MensajeriaPaqueteria.Infrastructure.Repositories.ClienteR;
using MensajeriaPaqueteria.Infrastructure.Repositories.MensajeroR;
using MensajeriaPaqueteria.Infrastructure.Repositories.EnvioR;
using MensajeriaPaqueteria.Infrastructure.Repositories.PaqueteR;
using MensajeriaPaqueteria.Infrastructure.Repositories.RutaR;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using MensajeriaPaqueteria.Api.Mappings;
using MensajeriaPaqueteria.Application.Contract;
using MensajeriaPaqueteria.Application.Services;
using MensajeriaPaqueteria.Api.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();




var Configuration = builder.Configuration;


builder.Services.AddDbContext<MensajeriaPaqueteriaDbContext>(options =>
    options.UseSqlServer(
        Configuration.GetConnectionString("MensajeriaPaqueteriaDbs"),
        b => b.MigrationsAssembly("MensajeriaPaqueteria.Infrastructure.Data")
    ));


builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IMensajeroRepository, MensajeroRepository>();
builder.Services.AddScoped<IRutaRepository, RutaRepository>();
builder.Services.AddScoped<IPaqueteRepository, PaqueteRepository>();
builder.Services.AddScoped<IEnvioRepository, EnvioRepository>();
builder.Services.AddScoped<IUbicacionRepository, UbicacionRepository>();


builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IMensajeroService, MensajeroService>();
builder.Services.AddScoped<IRutaService, RutaService>();
builder.Services.AddScoped<IPaqueteService, PaqueteService>();
builder.Services.AddScoped<IEnvioService, EnvioService>();
builder.Services.AddScoped<IUbicacionService, UbicacionService>();


var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.AllowAnyOrigin()
                                .AllowAnyMethod()
                                .AllowAnyHeader();
                      });
});



builder.Services.AddControllers();



builder.Services.AddAutoMapper(typeof(MappingProfile));

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseCors(MyAllowSpecificOrigins);

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapHub<TrackingHub>("/trackingHub"); // ruta del hub


app.MapControllers();




app.Run();