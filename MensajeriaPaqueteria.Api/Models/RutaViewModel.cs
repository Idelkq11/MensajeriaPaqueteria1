using MensajeriaPaqueteria.Domain.Entities;
using MensajeriaPaqueteria.Infrastructure.Repositories.RutaR;
using Microsoft.AspNetCore.Mvc;

namespace MensajeriaPaqueteria.Application.ViewModels
{
    public class RutaViewModel
    {
        public int RutaID { get; set; }
        public  string? Origen { get; set; }
        public  string? Destino { get; set; }
        public  string? Estado { get; set; } 
        public int MensajeroID { get; set; }
        
    }
}



