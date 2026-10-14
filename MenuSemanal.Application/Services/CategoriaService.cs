using MenuSemanal.Application.DTOs;
using MenuSemanal.Application.Interfaces;
using MenuSemanal.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuSemanal.Application.Services
{
    public class CategoriaService:ICategoriaService
    {
        private readonly ICategoriaRepository _repository;

        public CategoriaService(ICategoriaRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<CategoriaDto>> GetAllAsync()
        {
            var categorias = await _repository.GetAllAsync();
            return categorias.Select(p => new CategoriaDto
            {
                Id = p.Id,
                Nombre = p.Nombre
              
            });
        }

        public async Task<CategoriaDto?> GetByIdAsync(int id)
        {
            var categoria = await _repository.GetByIdAsync(id);
            if (categoria == null) return null;

            return new CategoriaDto
            {
                Id = categoria.Id,
                Nombre = categoria.Nombre
                
            };
        }


    }
}
