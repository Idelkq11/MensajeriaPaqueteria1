namespace MensajeriaPaqueteria.Api.Models
{
    public class EmpleadoViewModel
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public required string Cargo { get; set; }
        public required string Telefono { get; set; }
    }
}
