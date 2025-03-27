using MensajeriaPaqueteria.Domain.Entities;
using MensajeriaPaqueteria.Infrastructure.Repositories.EnvioR;
using Microsoft.AspNetCore.Mvc;
namespace MensajeriaPaqueteria.Api.Models
{
    public class MensajeroViewModel
    {
        public int MensajeroId { get; set; }
        public  string? Nombre { get; set; }
        public  string? Telefono { get; set; }
        public  string? Vehiculo { get; set; } 
        public string? Estado { get; set; }

    }
}