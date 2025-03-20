namespace MensajeriaPaqueteria.Api.Models
{
    public class EnvioViewModel
    {
        public int Id { get; set; }

        // Relación con Paquete
        public int PaqueteId { get; set; }

        // Relación con Cliente
        public int ClienteId { get; set; }

        // Relación con Empleado
        public int EmpleadoId { get; set; }

        public DateTime FechaEnvio { get; set; }
        public DateTime FechaEntrega { get; set; }
        public string? Estado { get; set; }
        public string? Nombre { get; set; }
    }
}

