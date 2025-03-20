using System.ComponentModel.DataAnnotations.Schema;

namespace MensajeriaPaqueteria.Domain.Entities
{
    public class Envio
    {
        public int Id { get; set; }

        // Relación con Paquete
        public int PaqueteId { get; set; }
        public Paquete? Paquete { get; set; }

        // Relación con Cliente
        public int ClienteId { get; set; }
        public Cliente? Cliente { get; set; }

        // Relación con Empleado
        public int EmpleadoId { get; set; }
        public Empleado? Empleado { get; set; }

        public DateTime FechaEnvio { get; set; }
        public DateTime FechaEntrega { get; set; }
        public string? Estado { get; set; }
        

    }
}

