using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class CiudadConfiguration : IEntityTypeConfiguration<Ciudad>
    {
        public void Configure(EntityTypeBuilder<Ciudad> builder)
        {
            //throw new NotImplementedException();
            builder.ToTable("ciudad");

            builder.Property(p => p.NombreCiudad)
            .IsRequired()
            .HasMaxLength(50);

            builder.HasOne(p => p.Departamento)
            .WithMany(p => p.Ciudades)
            .HasForeignKey(p => p.IdDepFk);
        }
    }
}