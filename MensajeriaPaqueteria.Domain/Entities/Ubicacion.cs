namespace MensajeriaPaqueteria.Domain.Entities
{
    public class Ubicacion
    {
        public int UbicacionId { get; set; }
        public int MensajeroId { get; set; }
        public double Latitud { get; set; }
        public double Longitud { get; set; }
        public DateTime FechaHora { get; set; }

        public Mensajero? Mensajero { get; set; }
    }
}
