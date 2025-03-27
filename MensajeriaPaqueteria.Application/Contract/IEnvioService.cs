using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MensajeriaPaqueteria.Application.Core;
using MensajeriaPaqueteria.Application.Dtos;

namespace MensajeriaPaqueteria.Application.Contract
{
    public interface IEnvioService
    {
        Task<IEnumerable<EnvioDto>> GetAllAsync();
        Task<EnvioDto> GetByIdAsync(int id);
        Task<ServiceResult> CreateAsync(EnvioDto envioDto);
        Task<ServiceResult> UpdateAsync(int id, EnvioDto envioDto);
        Task<ServiceResult> DeleteAsync(int id);
    }
}

