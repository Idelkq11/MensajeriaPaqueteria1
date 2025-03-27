namespace MensajeriaPaqueteria.Domain.Entities
{

    public class Mensajero
    {
        public int  MensajeroId { get; set; }
        public required string Nombre { get; set; }
        public required string Telefono { get; set; }
        public required string Vehiculo { get; set; } 
        public required string Estado { get; set; }

    }
}

         
    


