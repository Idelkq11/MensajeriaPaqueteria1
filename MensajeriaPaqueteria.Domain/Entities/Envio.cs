using System;
using MensajeriaPaqueteria.Domain.Entities;

namespace MensajeriaPaqueteria.Domain.Entities
{
    public class Envio
    {
        public int Id { get; set; }

        // Relación con Paquete
        public int PaqueteId { get; set; }
        public required Paquete Paquete { get; set; }

        // Relación con Cliente
        public int ClienteId { get; set; }
        public required Cliente Cliente { get; set; }

        // Relación con Empleado
        public int EmpleadoId { get; set; }
        public required Empleado Empleado { get; set; }

        public DateTime FechaEnvio { get; set; }
        public DateTime FechaEntrega { get; set; }
        public required string Estado { get; set; }

        // Relación con Ruta
        public int RutaId { get; set; }
        public required Ruta Ruta { get; set; }
    }
}
