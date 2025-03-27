using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MensajeriaPaqueteria.Application.Core;
using MensajeriaPaqueteria.Application.Dtos;

namespace MensajeriaPaqueteria.Application.Contract
{
    public interface IClienteService
    {
        Task<IEnumerable<ClienteDto>> GetAllAsync();
        Task<ClienteDto> GetByIdAsync(int id);
        Task<ServiceResult> CreateAsync(ClienteDto clienteDto);
        Task<ServiceResult> UpdateAsync(int id, ClienteDto clienteDto);
        Task<ServiceResult> DeleteAsync(int id);
    }
}
