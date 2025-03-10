namespace MensajeriaPaqueteria.Domain.Entities
{
    public class Paquete
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public required double Peso { get; set; }
        public required string Estado { get; set; }
        public string? Descripcion { get; set; } // Agregar la propiedad Descripcion

        // Relación con Envio
        public required List<Envio> Envio { get; set; }
    }
}
