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
    public class DiaSemanaService:IDiaSemanaService
    {
        private readonly IDiaSemanaRepository _repository;

        public DiaSemanaService(IDiaSemanaRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<DiaSemanaDto>> GetAllAsync()
        {
            var diaSemanas = await _repository.GetAllAsync();
            return diaSemanas.Select(p => new DiaSemanaDto
            {
                Id = p.Id,
                Nombre = p.Nombre
              
            });
        }

        public async Task<DiaSemanaDto?> GetByIdAsync(int id)
        {
            var diaSemana = await _repository.GetByIdAsync(id);
            if (diaSemana == null) return null;

            return new DiaSemanaDto
            {
                Id = diaSemana.Id,
                Nombre = diaSemana.Nombre
                
            };
        }


    }
}
