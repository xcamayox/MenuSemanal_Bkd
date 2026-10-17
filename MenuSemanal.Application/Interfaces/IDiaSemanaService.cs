using MenuSemanal.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuSemanal.Application.Interfaces
{
    public interface IDiaSemanaService
    {
        Task<IEnumerable<DiaSemanaDto>> GetAllAsync();
        Task<DiaSemanaDto?> GetByIdAsync(int id);

    }
}
