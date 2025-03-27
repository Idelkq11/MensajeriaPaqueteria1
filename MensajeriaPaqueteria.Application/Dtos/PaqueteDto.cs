
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MensajeriaPaqueteria.Application.Dtos
{
    public class PaqueteDto
    {
        public int PaqueteId { get; set; }
        public string TipoPaquete { get; set; } = string.Empty;  
        public decimal Peso { get; set; }
        public string EstadoPaquete { get; set; } = string.Empty;  
        public DateTime FechaEnvio { get; set; }
        public int ClienteId { get; set; }
        public string ClienteNombre { get; set; } = string.Empty;  
    }
}
