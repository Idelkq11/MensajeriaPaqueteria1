namespace MensajeriaPaqueteria.Domain.Entities
{
    public class Ruta
    {
        public int Id { get; set; }
        public required string Origen { get; set; }
        public required string Destino { get; set; }
        public required double Distancia { get; set; }

        // Relación con Empleado (agregado)
        public int EmpleadoId { get; set; }
        public required Empleado Empleado { get; set; }
    }
}
