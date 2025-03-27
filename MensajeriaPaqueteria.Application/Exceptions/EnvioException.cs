using System;

namespace MensajeriaPaqueteria.Application.Exceptions
{
    public class EnvioNotFoundException : Exception
    {
        public EnvioNotFoundException(int id)
            : base($"Envío con ID {id} no encontrado.")
        {
        }
    }
}

