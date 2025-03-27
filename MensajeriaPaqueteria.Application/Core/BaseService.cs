using System;

namespace MensajeriaPaqueteria.Application.Core
{
    public abstract class BaseService
    {
        
        protected ServiceResult CreateSuccessResult(string message = "Operación exitosa.")
        {
            return ServiceResult.Success(message); 
        }

        
        protected ServiceResult CreateFailureResult(string message)
        {
            return ServiceResult.Failure(message); 
        }
    }
}

