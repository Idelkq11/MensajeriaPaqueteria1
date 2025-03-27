using System;

namespace MensajeriaPaqueteria.Application.Exceptions
{
    public class PaqueteNotFoundException : Exception
    {
        public PaqueteNotFoundException(int id)
            : base($"Paquete con ID {id} no encontrado.")
        {
        }
    }
}
