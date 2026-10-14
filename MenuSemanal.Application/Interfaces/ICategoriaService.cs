using MenuSemanal.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuSemanal.Application.Interfaces
{
    public interface ICategoriaService
    {
        Task<IEnumerable<CategoriaDto>> GetAllAsync();
        Task<CategoriaDto?> GetByIdAsync(int id);

    }
}
