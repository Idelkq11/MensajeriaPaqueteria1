
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MensajeriaPaqueteria.Application.Dtos
{
    public class EnvioDto
    {
        public int EnvioId { get; set; }
        public DateTime FechaEnvio { get; set; }
        public string Direccion { get; set; } = string.Empty;  
        public int  PaqueteId { get; set; }
        public string PaqueteTipo { get; set; } = string.Empty;  
    }
}
