
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MensajeriaPaqueteria.Application.Dtos
{
    public class RutaDto
    {
        public int RutaId { get; set; }
        public string Origen { get; set; } = string.Empty; 
        public string Destino { get; set; } = string.Empty;  
        public string EstadoRuta { get; set; } = string.Empty;  
        public int MensajeroId { get; set; }
        public string MensajeroNombre { get; set; } = string.Empty;  
    }
}
