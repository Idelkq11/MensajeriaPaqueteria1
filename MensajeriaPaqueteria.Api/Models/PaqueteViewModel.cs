using MensajeriaPaqueteria.Domain.Entities;
using MensajeriaPaqueteria.Infrastructure.Repositories.PaqueteR;
using Microsoft.AspNetCore.Mvc;

namespace MensajeriaPaqueteria.Application.ViewModels
{
    public class PaqueteViewModel
    {
        public int PaqueteID { get; set; }
        public string? TipoPaquete { get; set; }
        public decimal Peso { get; set; }
        public string? EstadoPaquete { get; set; }
        public DateTime FechaEnvio { get; set; }
        public int ClienteID { get; set; }
    }
}