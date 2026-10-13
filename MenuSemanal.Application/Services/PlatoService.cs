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
    public class PlatoService : IPlatoService
    {
        private readonly IPlatoRepository _repository;

        public PlatoService(IPlatoRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<PlatoDto>> GetAllAsync()
        {
            var platos = await _repository.GetAllAsync();
            return platos.Select(p => new PlatoDto
            {
                Id = p.Id,
                Nombre = p.Nombre,
                IdCategoria = p.IdCategoria,
                Usado = p.Usado
            });
        }

        public async Task<PlatoDto?> GetByIdAsync(int id)
        {
            var plato = await _repository.GetByIdAsync(id);
            if (plato == null) return null;

            return new PlatoDto
            {
                Id = plato.Id,
                Nombre = plato.Nombre,
                IdCategoria = plato.IdCategoria,
                Usado = plato.Usado
            };
        }

        public async Task<PlatoDto> CreateAsync(CreatePlatoDto dto)
        {
            var plato = new Plato
            {
                Nombre = dto.Nombre,
                IdCategoria = dto.IdCategoria,
                Usado = dto.Usado
                
            };

            var nuevoPlato = await _repository.CreateAsync(plato);

            return new PlatoDto
            {
                Id = nuevoPlato.Id,
                Nombre = nuevoPlato.Nombre,
                IdCategoria = nuevoPlato.IdCategoria,
                Usado = nuevoPlato.Usado
            
            };
        }

        public async Task<bool> UpdateAsync(int id, UpdatePlatoDto dto)
        {
            var plato = await _repository.GetByIdAsync(id);
            if (plato == null) return false;

            plato.Nombre = dto.Nombre;
            plato.IdCategoria = dto.IdCategoria;
            plato.Usado = dto.Usado;

            await _repository.UpdateAsync(plato);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var plato = await _repository.GetByIdAsync(id);
            if (plato == null) return false;

            await _repository.DeleteAsync(id);
            return true;
        }
    }
}
