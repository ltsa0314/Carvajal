using Carvajal.Domain.Models;
using Carvajal.Infraestructure.Data;
using Carvajal.Infraestructure.Implementations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Xunit;

namespace Carvajal.Tests.Unit.Repositories
{
    public class TypeIdentificationRepositoryTest
    {
        [Fact]
        public void GetAll()
        {
            // Arrange
            var builder = new DbContextOptionsBuilder<CarvajalDbContext>();
            var options = builder.UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
            using var context = new CarvajalDbContext(options);
            context.Database.EnsureDeleted();

            var entity = new TypeIdentification
            {
                Description = "Cedula Ciudadania"
            };

            context.TypeIdentifications.Add(entity);
            context.SaveChanges();

            // Action
            var repository = new TypeIdentificationRepository(context);
            var entities = repository.GetAll();

            // Assert
            Assert.True(entities != null);
            Assert.True(entities.Count() > 0);
            Assert.True(entities.LastOrDefault().Description == "Cedula Ciudadania");
        }
    }
}
