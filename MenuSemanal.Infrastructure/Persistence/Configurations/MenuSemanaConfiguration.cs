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
    public class MenuSemanaConfiguration : IEntityTypeConfiguration<MenuSemana>
    {
        public void Configure(EntityTypeBuilder<MenuSemana> builder)
        {
            builder.ToTable("menusemanal");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(p => p.IdDia)
                   .HasColumnName("iddia")
                   .IsRequired();
                   
            builder.Property(p => p.IdCategoria)
                 .HasColumnName("idcategoria")
                 .IsRequired();

            builder.Property(p => p.IdPlato)
                 .HasColumnName("idplato")
                 .IsRequired();

           

            // Ejemplo si tienes una relación con Categoria (Foreing Key)
            // builder.HasOne(p => p.Categoria)
            //        .WithMany(c => c.Platos)
            //        .HasForeignKey(p => p.CategoriaId);
        }
    }
}
