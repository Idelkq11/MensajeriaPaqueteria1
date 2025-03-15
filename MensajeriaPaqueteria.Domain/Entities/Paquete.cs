namespace MensajeriaPaqueteria.Domain.Entities
{
    public class Paquete
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public required double Peso { get; set; }
        public required string Estado { get; set; }
        public string? Descripcion { get; set; } // Descripción opcional
                                                 // Relación con Cliente (Un Paquete pertenece a un Cliente)
        public int ClienteId { get; set; } // Clave foránea
        public required Cliente Cliente { get; set; } // Propiedad de navegación

        // Relación con Envio (1 Paquete puede tener muchos Envios)
        public required List<Envio> Envio { get; set; }
    }
}
