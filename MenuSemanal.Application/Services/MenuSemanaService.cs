using MenuSemanal.Application.DTOs;
using MenuSemanal.Application.Interfaces;
using MenuSemanal.Domain.Entities;
using MenuSemanal.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuSemanal.Application.Services
{
    public class MenuSemanaService : IMenuSemanaService
    {
        private readonly IMenuSemanaRepository _repository;

        public MenuSemanaService(IMenuSemanaRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<MenuSemanaDto>> GetAllAsync()
        {
            var platos = await _repository.GetAllAsync();
            return platos.Select(p => new MenuSemanaDto
            {
                Id = p.Id,
                IdDia = p.IdDia,
                IdCategoria = p.IdCategoria,
                IdPlato = p.IdPlato,
                IdUsuario= p.IdUsuario,
            });
        }

        public async Task<MenuSemanaDto?> GetByIdAsync(int id)
        {
            var plato = await _repository.GetByIdAsync(id);
            if (plato == null) return null;

            return new MenuSemanaDto
            {
                Id = plato.Id,
                IdDia = plato.IdDia,
                IdCategoria = plato.IdCategoria,
                IdPlato = plato.IdPlato,
                IdUsuario= plato.IdUsuario,
            };
        }

        public async Task<MenuSemanaDto> CreateAsync(CreateMenuSemanaDto dto)
        {
            var plato = new MenuSemana
            {
                IdDia = dto.IdDia,
                IdCategoria = dto.IdCategoria,
                IdPlato = dto.IdPlato,
                IdUsuario= dto.IdUsuario,
                
            };

            var nuevoPlato = await _repository.CreateAsync(plato);

            return new MenuSemanaDto
            {
                Id = nuevoPlato.Id,
                IdDia = nuevoPlato.IdDia,
                IdCategoria = nuevoPlato.IdCategoria,
                IdPlato = nuevoPlato.IdPlato,
                IdUsuario=nuevoPlato.IdUsuario,
            };
        }
        public async Task<bool> ReemplazarMenuAsync(List<MenuSemanaDto> nuevosMenus)
        {
            if (nuevosMenus == null || !nuevosMenus.Any()) return false;

            // Obtenemos el ID del usuario del primer elemento del arreglo
            int idUsuario = nuevosMenus.First().IdUsuario;

            // 1. Buscar los menús anteriores de ese usuario
            var menusAnteriores = await _repository.GetByUsuarioIdAsync(idUsuario);

            // 2. Si existen, eliminarlos
            if (menusAnteriores.Any())
            {
                await _repository.DeleteRangeAsync(menusAnteriores);
            }
            var nuevosMenusEntidad = nuevosMenus.Select(dto => new MenuSemana
            {
                IdUsuario = dto.IdUsuario,
                IdDia = dto.IdDia,
                IdPlato = dto.IdPlato,
                IdCategoria = dto.IdCategoria
            }).ToList();
            // 3. Agregar los nuevos platos masivamente
            await _repository.AddRangeAsync(nuevosMenusEntidad);
           
            // 4. Persistir los cambios en la BD
            await _repository.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(int id, UpdateMenuSemanaDto dto)
        {
            var menu = await _repository.GetByIdAsync(id);
            if (menu == null) return false;

            menu.IdDia = dto.IdDia;
            menu.IdCategoria = dto.IdCategoria;
            menu.IdPlato = dto.IdPlato;
            menu.IdUsuario= dto.IdUsuario;

            await _repository.UpdateAsync(menu);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var menu = await _repository.GetByIdAsync(id);
            if (menu == null) return false;

            await _repository.DeleteAsync(id);
            return true;
        }

        

        public async Task SaveChangesAsync()
        {
            await _repository.SaveChangesAsync();
        }
    }
}
