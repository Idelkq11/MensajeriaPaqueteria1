using MensajeriaPaqueteria.Domain.Entities;
using MensajeriaPaqueteria.Infrastructure.Repositories.EnvioR;
using Microsoft.AspNetCore.Mvc;

namespace MensajeriaPaqueteria.Api.Models
{
    public class EnvioViewModel
    {

        public int EnvioId { get; set; }
        public DateTime FechaEnvio { get; set; }
        public string? Direccion { get; set; }
        public int PaqueteID { get; set; }

    }
}
