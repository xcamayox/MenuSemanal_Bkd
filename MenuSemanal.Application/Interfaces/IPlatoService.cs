using MenuSemanal.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuSemanal.Application.Interfaces
{
    public interface IPlatoService
    {
        Task<IEnumerable<PlatoDto>> GetAllAsync();
        Task<PlatoDto?> GetByIdAsync(int id);
        Task<PlatoDto> CreateAsync(CreatePlatoDto dto);
        Task<bool> UpdateAsync(int id, UpdatePlatoDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
