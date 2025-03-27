using System;

namespace MensajeriaPaqueteria.Application.Exceptions
{
    public class ClienteNotFoundException : Exception
    {
        public ClienteNotFoundException(int id)
            : base($"Cliente con ID {id} no encontrado.")
        {
        }
    }
}

