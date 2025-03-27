
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MensajeriaPaqueteria.Application.Dtos
{
    public class MensajeroDto
    {
        public int MensajeroId { get; set; }
        public string Nombre { get; set; } = string.Empty; 
        public string Telefono { get; set; } = string.Empty; 
        public string Vehiculo { get; set; } = string.Empty; 
        public string Estado { get; set; } = string.Empty;  
    }
}
