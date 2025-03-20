using MensajeriaPaqueteria.Api.Models;

namespace MensajeriaPaqueteria.Domain.Entities
{
    public class RutaViewModel
    {
        public int Id { get; set; }
        public required string Origen { get; set; }
        public required string Destino { get; set; }
        public double Distancia { get; set; }
        public required EnvioViewModel Envio { get; set; }


    }
}


