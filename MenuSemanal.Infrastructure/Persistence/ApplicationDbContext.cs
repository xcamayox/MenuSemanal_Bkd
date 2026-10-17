using MenuSemanal.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuSemanal.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Plato> Platos => Set<Plato>();
        public DbSet<Categoria> Categorias => Set<Categoria>();
        public DbSet<DiaSemana> DiasSemana => Set<DiaSemana>();
        public DbSet<MenuSemana> MenuSemana => Set<MenuSemana>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Esta línea detecta y aplica automáticamente todas las configuraciones anteriores
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
