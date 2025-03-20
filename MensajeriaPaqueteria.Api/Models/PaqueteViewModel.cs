namespace MensajeriaPaqueteria.Api.Models
{
    public class PaqueteViewModel
    {
        public int Id { get; set; }
        public required string Nombre { get; set; }
        public double Peso { get; set; }
        public required string Estado { get; set; }
        public string? Descripcion { get; set; }
        public int ClienteId { get; set; }
    }
}
