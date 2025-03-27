namespace MensajeriaPaqueteria.Domain.Entities
{

    public class Paquete
    {
        public int PaqueteId { get; set; }
        public required string TipoPaquete { get; set; } 
        public decimal Peso { get; set; }
        public required string EstadoPaquete { get; set; } 
        public DateTime FechaEnvio { get; set; }
        

        public int  ClienteId { get; set; }
        public  Cliente? Cliente { get; set; } 
    }
}










