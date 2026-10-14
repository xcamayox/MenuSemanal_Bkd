using MenuSemanal.Domain.Entities;
using MenuSemanal.Domain.Interfaces;
using MenuSemanal.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace MenuSemanal.Infrastructure.Repositories;

public class PlatoRepository : IPlatoRepository
{
    private readonly ApplicationDbContext _context;

    public PlatoRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Plato>> GetAllAsync()
    {
        return await _context.Platos.ToListAsync();
    }

    public async Task<Plato?> GetByIdAsync(int id)
    {
        return await _context.Platos.FindAsync(id);
    }

    public async Task<Plato> CreateAsync(Plato plato)
    {
        _context.Platos.Add(plato);
        await _context.SaveChangesAsync();
        return plato;
    }

    public async Task UpdateAsync(Plato plato)
    {
        _context.Platos.Update(plato);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var plato = await GetByIdAsync(id);
        if (plato != null)
        {
            _context.Platos.Remove(plato);
            await _context.SaveChangesAsync();
        }
    }
}