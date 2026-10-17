using MenuSemanal.Domain.Entities;
using MenuSemanal.Domain.Interfaces;
using MenuSemanal.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuSemanal.Infrastructure.Repositories
{
    public class DiaSemanaRepository : IDiaSemanaRepository
    {
        private readonly ApplicationDbContext _context;

        public DiaSemanaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DiaSemana>> GetAllAsync()
        {
            return await _context.DiasSemana.ToListAsync();
        }

        public async Task<DiaSemana?> GetByIdAsync(int id)
        {
            return await _context.DiasSemana.FindAsync(id);
        }

    }
}
