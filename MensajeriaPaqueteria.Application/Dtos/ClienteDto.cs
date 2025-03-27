using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MensajeriaPaqueteria.Application.Dtos
{
    public class ClienteDto
    {
        public int ClienteId { get; set; }
        public string Nombre { get; set; } = string.Empty;  
        public string Direccion { get; set; } = string.Empty; 
        public string Telefono { get; set; } = string.Empty;  
    }
}
