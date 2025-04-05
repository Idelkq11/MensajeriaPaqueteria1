using Microsoft.AspNetCore.SignalR;

namespace MensajeriaPaqueteria.Web.Hubs
{
    public class TrackingHub : Hub
    {
        // Este método se usará para enviar actualizaciones del estado del envío
        public async Task EnviarEstado(string envioId, string nuevoEstado)
        {
            await Clients.All.SendAsync("ReceiveUpdate", envioId, nuevoEstado);
        }

        // Este método se usará para notificar asignaciones de mensajero
        public async Task AsignarMensajero(string envioId, string mensajero)
        {
            await Clients.All.SendAsync("MensajeroAsignado", envioId, mensajero);
        }
    }
}
