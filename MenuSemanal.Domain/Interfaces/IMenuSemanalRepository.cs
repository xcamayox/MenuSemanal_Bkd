
using MenuSemanal.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuSemanal.Domain.Interfaces
{
    public interface IMenuSemanaRepository
    {
        Task<IEnumerable<MenuSemana>> GetAllAsync();
        Task<MenuSemana?> GetByIdAsync(int id);
        Task<MenuSemana> CreateAsync(MenuSemana menu);
        Task UpdateAsync(MenuSemana menu);
        Task DeleteAsync(int id);
        //Task DeleteByUsuario(int idusuario);
        Task<IEnumerable<MenuSemana>> GetByUsuarioIdAsync(int idUsuario);
        Task DeleteRangeAsync(IEnumerable<MenuSemana> menus);
        Task AddRangeAsync(IEnumerable<MenuSemana> menus);
        Task SaveChangesAsync();
    }
}
