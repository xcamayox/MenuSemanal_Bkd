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
                IdPlato = p.IdPlato
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
                IdPlato = plato.IdPlato
            };
        }

        public async Task<MenuSemanaDto> CreateAsync(CreateMenuSemanaDto dto)
        {
            var plato = new MenuSemana
            {
                IdDia = dto.IdDia,
                IdCategoria = dto.IdCategoria,
                IdPlato = dto.IdPlato
                
            };

            var nuevoPlato = await _repository.CreateAsync(plato);

            return new MenuSemanaDto
            {
                Id = nuevoPlato.Id,
                IdDia = nuevoPlato.IdDia,
                IdCategoria = nuevoPlato.IdCategoria,
                IdPlato = nuevoPlato.IdPlato
            
            };
        }

        public async Task<bool> UpdateAsync(int id, UpdateMenuSemanaDto dto)
        {
            var menu = await _repository.GetByIdAsync(id);
            if (menu == null) return false;

            menu.IdDia = dto.IdDia;
            menu.IdCategoria = dto.IdCategoria;
            menu.IdPlato = dto.IdPlato;

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
    }
}
