using MenuSemanal.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuSemanal.Application.Interfaces
{
    public interface IMenuSemanaService
    {
        Task<IEnumerable<MenuSemanaDto>> GetAllAsync();
        Task<MenuSemanaDto?> GetByIdAsync(int id);
        Task<MenuSemanaDto> CreateAsync(CreateMenuSemanaDto dto);
        Task<bool> UpdateAsync(int id, UpdateMenuSemanaDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
