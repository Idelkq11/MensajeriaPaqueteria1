using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MensajeriaPaqueteria.Domain.Entities
{
    public class Ruta
    {
        public int Id { get; set; }
        public required string Origen { get; set; }
        public required string Destino { get; set; }
        public double Distancia { get; set; }
        public required List<Envio> Envio { get; set; }

    }
}

    
 