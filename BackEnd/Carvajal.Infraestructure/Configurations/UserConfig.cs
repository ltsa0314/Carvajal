using Carvajal.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace Carvajal.Infraestructure.Configurations
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(100);
            builder.Property(x => x.TypeIdentificationId).IsRequired();
            builder.Property(x => x.Identification).IsRequired().HasMaxLength(21);
            builder.Property(x => x.Password).IsRequired().HasMaxLength(20);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(500);

            // Seed Data
            builder.HasData(new List<User>
            {
                new User {
                    Id = 1,
                    Name = "Leidy Tatina",
                    LastName = "Sanchez Arevalo",
                    TypeIdentificationId = 1,
                    Identification = "1110544973",
                    Email = "ltsa0314@gmail.com",
                    Password = "Tatiana@2021"
                }
            });
        }
    }
}
