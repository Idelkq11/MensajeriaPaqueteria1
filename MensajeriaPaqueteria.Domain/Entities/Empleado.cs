using System;

namespace MensajeriaPaqueteria.Domain.Entities
{
    public class Empleado
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public required string Cargo { get; set; }
        public required string Telefono { get; set; }
    }
}
