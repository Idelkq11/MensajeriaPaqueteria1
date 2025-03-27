using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MensajeriaPaqueteria.Domain.Entities
{

    public class Envio
    {
        public int EnvioId { get; set; }
        public DateTime FechaEnvio { get; set; }
        public required string Direccion { get; set; }
        public int PaqueteId { get; set; }
        public Paquete? Paquete { get; set; } 
    }

}
