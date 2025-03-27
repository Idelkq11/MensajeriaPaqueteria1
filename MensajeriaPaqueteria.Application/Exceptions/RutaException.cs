using System;

namespace MensajeriaPaqueteria.Application.Exceptions
{
    public class RutaNotFoundException : Exception
    {
        public RutaNotFoundException(int id)
            : base($"Ruta con ID {id} no encontrada.")
        {
        }
    }
}
