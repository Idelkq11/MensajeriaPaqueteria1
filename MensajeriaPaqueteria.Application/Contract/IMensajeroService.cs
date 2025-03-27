using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using MensajeriaPaqueteria.Application.Dtos;
using MensajeriaPaqueteria.Application.Core;

namespace MensajeriaPaqueteria.Application.Contract
{
    public interface IMensajeroService
    {
        Task<IEnumerable<MensajeroDto>> GetAllAsync(); 
        Task<MensajeroDto> GetByIdAsync(int id);  
        Task<ServiceResult> CreateAsync(MensajeroDto mensajeroDto);  
        Task<ServiceResult> UpdateAsync(int id, MensajeroDto mensajeroDto);  
        Task<ServiceResult> DeleteAsync(int id);  
    }
}
