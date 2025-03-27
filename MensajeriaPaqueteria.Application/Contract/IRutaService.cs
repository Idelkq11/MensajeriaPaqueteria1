using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MensajeriaPaqueteria.Application.Core;
using MensajeriaPaqueteria.Application.Dtos;

namespace MensajeriaPaqueteria.Application.Contract
{
    public interface IRutaService
    {
        Task<IEnumerable<RutaDto>> GetAllAsync();
        Task<RutaDto> GetByIdAsync(int id);
        Task<ServiceResult> CreateAsync(RutaDto rutaDto);
        Task<ServiceResult> UpdateAsync(int id, RutaDto rutaDto);
        Task<ServiceResult> DeleteAsync(int id);
    }
}

