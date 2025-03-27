using MensajeriaPaqueteria.Domain.Entities;

public class Ruta
{
    public int RutaId { get; set; }
    public required string Origen { get; set; }
    public required string Destino { get; set; }
    public required string EstadoRuta { get; set; } 
    public int MensajeroId { get; set; }

    public  Mensajero? Mensajero { get; set; } 
}
