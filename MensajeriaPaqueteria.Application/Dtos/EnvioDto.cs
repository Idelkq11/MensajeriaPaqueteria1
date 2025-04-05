using System;
using System.ComponentModel.DataAnnotations;

namespace MensajeriaPaqueteria.Application.Dtos
{
    public class EnvioDto
    {
        public int EnvioId { get; set; }

        [Required(ErrorMessage = "La fecha de envío es obligatoria.")]
        public DateTime FechaEnvio { get; set; }

        [Required(ErrorMessage = "La dirección es obligatoria.")]
        [StringLength(255, ErrorMessage = "La dirección no puede superar los 255 caracteres.")]
        public string Direccion { get; set; } = string.Empty;

        [Required(ErrorMessage = "Debe asociarse un paquete.")]
        public int PaqueteId { get; set; }

        public string PaqueteTipo { get; set; } = string.Empty;

        // ✅ Nueva propiedad: Ubicación actual (Latitud, Longitud)
        public string? UbicacionActual { get; set; }

        // ✅ Nueva propiedad: Estado del envío (Pendiente, En camino, Entregado)
        [Required(ErrorMessage = "El estado del envío es obligatorio.")]
        public string Estado { get; set; } = "Pendiente";

        // ✅ Nueva propiedad: Firma de entrega (Imagen en Base64)
        public string? FirmaEntrega { get; set; }
    }
}
