using MenuSemanal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuSemanal.Domain.Interfaces
{
    public interface IDiaSemanaRepository
    {

        Task<IEnumerable<DiaSemana>> GetAllAsync();
        Task<DiaSemana?> GetByIdAsync(int id);
    }
}
