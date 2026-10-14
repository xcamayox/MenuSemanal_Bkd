using MenuSemanal.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MenuSemanal.Infrastructure.Persistence.Configurations
{
    public class PlatoConfiguration : IEntityTypeConfiguration<Plato>
    {
        public void Configure(EntityTypeBuilder<Plato> builder)
        {
            builder.ToTable("platos");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Nombre)
                   .HasColumnName("nombre")
                   .IsRequired()
                   .HasMaxLength(150);

            builder.Property(p => p.IdCategoria)
                 .HasColumnName("idcategoria");

            builder.Property(p => p.Usado)
                 .HasColumnName("usado");

            builder.Property(p => p.FotoUrl)
                 .HasColumnName("fotourl")
                 .IsRequired(false);

            builder.Property(p => p.FechaCreacion)
                 .HasColumnName("fechacreacion")
                 .HasDefaultValueSql("CURRENT_DATE") // Asigna la fecha actual por defecto en PostgreSQL
                 .IsRequired();

            // Ejemplo si tienes una relación con Categoria (Foreing Key)
            // builder.HasOne(p => p.Categoria)
            //        .WithMany(c => c.Platos)
            //        .HasForeignKey(p => p.CategoriaId);
        }
    }
}
