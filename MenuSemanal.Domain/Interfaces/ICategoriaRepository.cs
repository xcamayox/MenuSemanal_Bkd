using MenuSemanal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuSemanal.Domain.Interfaces
{
    public interface ICategoriaRepository
    {

        Task<IEnumerable<Categoria>> GetAllAsync();
        Task<Categoria?> GetByIdAsync(int id);
    }
}
