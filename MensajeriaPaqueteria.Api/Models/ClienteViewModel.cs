using MensajeriaPaqueteria.Domain.Entities;
using MensajeriaPaqueteria.Infrastructure.Repositories.ClienteR;
using Microsoft.AspNetCore.Mvc;

namespace MensajeriaPaqueteria.Api.Models
{
    public class ClienteViewModel
    {
        public int ClienteId { get; set; }
        public  string? Nombre { get; set; }
        public  string? Direccion { get; set; }
        public  string? Telefono { get; set; }
    
        
    }
}


