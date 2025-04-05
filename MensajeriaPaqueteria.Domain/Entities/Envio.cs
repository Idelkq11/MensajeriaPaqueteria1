using System;

namespace MensajeriaPaqueteria.Domain.Entities
{
    public class Envio
    {
        public int EnvioId { get; set; }
        public DateTime FechaEnvio { get; set; }
        public required string Direccion { get; set; }

        // Relación con Paquete
        public int PaqueteId { get; set; }
        public Paquete? Paquete { get; set; }

        // ✅ Nueva Propiedad: Ubicación actual (latitud,longitud)
        public string? UbicacionActual { get; set; }

        // ✅ Nueva Propiedad: Estado del envío (Pendiente, En camino, Entregado)
        public string Estado { get; set; } = "Pendiente";

        // ✅ Nueva Propiedad: Firma de la entrega (Imagen en Base64)
        public string? FirmaEntrega { get; set; }
    }
}
