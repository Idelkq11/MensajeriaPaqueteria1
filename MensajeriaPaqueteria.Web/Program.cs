using MensajeriaPaqueteria.Infrastructure.Data;
using MensajeriaPaqueteria.Web.Services;
using Microsoft.EntityFrameworkCore;
using MensajeriaPaqueteria.Application.Contract;
using MensajeriaPaqueteria.Application.Services;
using MensajeriaPaqueteria.Infrastructure.Repositories.ClienteR;
using MensajeriaPaqueteria.Infrastructure.Repositories.MensajeroR;
using MensajeriaPaqueteria.Infrastructure.Repositories.EnvioR;
using MensajeriaPaqueteria.Infrastructure.Repositories.PaqueteR;
using MensajeriaPaqueteria.Infrastructure.Repositories.RutaR;
using Microsoft.AspNetCore.SignalR;
using MensajeriaPaqueteria.Web.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

// Configuración de la base de datos
builder.Services.AddDbContext<MensajeriaPaqueteriaDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("MensajeriaPaqueteriaDbs")));

builder.Services.AddScoped<ApiService>();

// Repositorios y servicios
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

// Configuración de SignalR
builder.Services.AddSignalR();

builder.Services.AddHttpClient("ApiClient", client =>
{
    var apiBaseUrl = builder.Configuration["ApiBaseUrl"];
    if (!string.IsNullOrEmpty(apiBaseUrl))
    {
        client.BaseAddress = new Uri(apiBaseUrl);
    }
});

builder.Services.AddHttpsRedirection(options =>
{
    options.HttpsPort = 7162;
});

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
    options.Cookie.SameSite = SameSiteMode.Strict;
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
app.MapHub<TrackingHub>("/trackingHub");
app.UseHttpsRedirection();
app.UseCookiePolicy();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// Configuración de rutas de SignalR
app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();
    endpoints.MapFallbackToPage("/Home");
    endpoints.MapHub<TrackingHub>("/trackingHub");  // Aquí es donde mapeas el Hub
});

// Inicialización de la base de datos
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<MensajeriaPaqueteriaDbContext>();
    try
    {
        db.Database.EnsureCreated();
        Console.WriteLine("Conexión a la base de datos exitosa.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error al conectar con la base de datos: {ex.Message}");
    }
}

app.Run();
