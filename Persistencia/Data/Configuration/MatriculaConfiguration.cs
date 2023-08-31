using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class MatriculaConfiguration : IEntityTypeConfiguration<Matricula>
    {
        public void Configure(EntityTypeBuilder<Matricula> builder)
        {
            //throw new NotImplementedException();
            builder.ToTable("matricula");

            builder.HasOne(p => p.Persona)
            .WithMany(p => p.Matriculas)
            .HasForeignKey(p => p.IdPersonaFk);

            
            builder.HasOne(p => p.Salon)
            .WithMany(p => p.Matriculas)
            .HasForeignKey(p => p.IdSalonFk);
        }
    }
}