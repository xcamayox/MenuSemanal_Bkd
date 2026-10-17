using MenuSemanal.Domain.Entities;
using MenuSemanal.Domain.Interfaces;
using MenuSemanal.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace MenuSemanal.Infrastructure.Repositories;

public class MenuSemanaRepository : IMenuSemanaRepository
{
    private readonly ApplicationDbContext _context;

    public MenuSemanaRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<MenuSemana>> GetAllAsync()
    {
        return await _context.MenuSemana.ToListAsync();
    }

    public async Task<MenuSemana?> GetByIdAsync(int id)
    {
        return await _context.MenuSemana.FindAsync(id);
    }

    public async Task<MenuSemana> CreateAsync(MenuSemana menu)
    {
        _context.MenuSemana.Add(menu);
        await _context.SaveChangesAsync();
        return menu;
    }

    public async Task UpdateAsync(MenuSemana menu)
    {
        _context.MenuSemana.Update(menu);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var menu = await GetByIdAsync(id);
        if (menu != null)
        {
            _context.MenuSemana.Remove(menu);
            await _context.SaveChangesAsync();
        }
    }
}