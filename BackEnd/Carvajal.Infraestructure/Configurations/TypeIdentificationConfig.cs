using Carvajal.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace Carvajal.Infraestructure.Configurations
{
    public class TypeIdentificationConfig : IEntityTypeConfiguration<TypeIdentification>
    {
        public void Configure(EntityTypeBuilder<TypeIdentification> builder)
        {
            builder.ToTable("TypeIdentification");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.Description).IsRequired().HasMaxLength(120);

            // Seed Data
            builder.HasData(new List<TypeIdentification>
            {
                new TypeIdentification{ Id= 1 , Description = "CC - Cedula Ciudadania" },
                new TypeIdentification{ Id= 2 , Description = "RC - Registro Civil" },
                new TypeIdentification{ Id= 3 , Description = "TI - Tarjeta Identidad" },
                new TypeIdentification{ Id= 4 , Description = "CE - Cedula Extrajera" },
                new TypeIdentification{ Id= 5 , Description = "PA - Pasaporte" },
            });
        }
    }
}
