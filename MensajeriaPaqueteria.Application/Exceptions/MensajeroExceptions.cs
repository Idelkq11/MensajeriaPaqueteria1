using System;

namespace MensajeriaPaqueteria.Application.Exceptions
{
    public class MensajeroNotFoundException : Exception
    {
        public MensajeroNotFoundException(int id)
            : base($"Mensajero con ID {id} no encontrado.")
        {
        }
    }
}

