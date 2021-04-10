using Carvajal.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Carvajal.Infraestructure.Data
{
    public class CarvajalDbContext : DbContext
    {
        public CarvajalDbContext(DbContextOptions<CarvajalDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<TypeIdentification> TypeIdentifications { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Establecer Esquema por defecto de la Base de datos
            modelBuilder.HasDefaultSchema("dbo");

            // Cargar Configuracion de tablas manera automatica
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CarvajalDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
