using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MensajeriaPaqueteria.Application.Core;
using MensajeriaPaqueteria.Application.Dtos;

namespace MensajeriaPaqueteria.Application.Contract
{
    public interface IPaqueteService
    {
        Task<IEnumerable<PaqueteDto>> GetAllAsync();
        Task<PaqueteDto> GetByIdAsync(int id);
        Task<ServiceResult> CreateAsync(PaqueteDto paqueteDto);
        Task<ServiceResult> UpdateAsync(int id, PaqueteDto paqueteDto);
        Task<ServiceResult> DeleteAsync(int id);
    }
}
