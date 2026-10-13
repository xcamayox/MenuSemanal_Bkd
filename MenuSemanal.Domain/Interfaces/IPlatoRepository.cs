using MenuSemanal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuSemanal.Domain.Interfaces
{
    public interface IPlatoRepository
    {
        Task<IEnumerable<Plato>> GetAllAsync();
        Task<Plato?> GetByIdAsync(int id);
        Task<Plato> CreateAsync(Plato plato);
        Task UpdateAsync(Plato plato);
        Task DeleteAsync(int id);
    }
}
