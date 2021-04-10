using Carvajal.Domain.Models;
using Carvajal.Infraestructure.Data;
using Carvajal.Infraestructure.Implementations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Xunit;

namespace Carvajal.Tests.Unit.Repositories
{
    public class UserRepositoryTest
    {
        [Fact]
        public void Insert()
        {
            // Arrange
            var builder = new DbContextOptionsBuilder<CarvajalDbContext>();
            var options = builder.UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
            using var context = new CarvajalDbContext(options);
            context.Database.EnsureDeleted();

            var entity = new User
            {
                Name = "Leidy Tatina",
                LastName = "Sanchez Arevalo",
                TypeIdentificationId = 1,
                Identification = "1110544973",
                Email = "ltsa0314@gmail.com",
                Password = "Tatiana@2021"
            };

            // Action
            var repository = new UserRepository(context);
            entity = repository.Insert(entity);

            // Assert
            Assert.True(entity.Id > 0);
            Assert.True(entity.Name == "Leidy Tatina");
            Assert.True(entity.LastName == "Sanchez Arevalo");
            Assert.True(entity.TypeIdentificationId == 1);
            Assert.True(entity.Identification == "1110544973");
            Assert.True(entity.Email == "ltsa0314@gmail.com");
            Assert.True(entity.Password == "Tatiana@2021");
        }


        [Fact]
        public void Update()
        {
            // Arrange
            var builder = new DbContextOptionsBuilder<CarvajalDbContext>();
            var options = builder.UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
            using var context = new CarvajalDbContext(options);
            context.Database.EnsureDeleted();

            var entity = new User
            {
                Name = "Leidy Tatina",
                LastName = "Sanchez Arevalo",
                TypeIdentificationId = 1,
                Identification = "1110544973",
                Email = "ltsa0314@gmail.com",
                Password = "Tatiana@2021"
            };

            context.Users.Add(entity);
            context.SaveChanges();


            // Action
            var repository = new UserRepository(context);
            entity.Name = "Leidy";
            entity.LastName = "Sanchez";

            repository.Update(entity);

            // Assert
            var entityUpdated = context.Users.Find(entity.Id);

            Assert.True(entityUpdated.Name == "Leidy");
            Assert.True(entityUpdated.LastName == "Sanchez");
        }

        [Fact]
        public void Delete()
        {
            // Arrange
            var builder = new DbContextOptionsBuilder<CarvajalDbContext>();
            var options = builder.UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
            using var context = new CarvajalDbContext(options);
            context.Database.EnsureDeleted();

            var entity = new User
            {
                Name = "Leidy Tatina",
                LastName = "Sanchez Arevalo",
                TypeIdentificationId = 1,
                Identification = "1110544973",
                Email = "ltsa0314@gmail.com",
                Password = "Tatiana@2021"
            };

            context.Users.Add(entity);
            context.SaveChanges();

            // Act
            var repository = new UserRepository(context);
            repository.Delete(entity.Id);


            // Assert
            var entityDeleted = context.Users.Find(entity.Id);
            Assert.True(entityDeleted == null);
        }

        [Fact]
        public void GetById()
        {
            // Arrange
            var builder = new DbContextOptionsBuilder<CarvajalDbContext>();
            var options = builder.UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
            using var context = new CarvajalDbContext(options);
            context.Database.EnsureDeleted();

            var entity = new User
            {
                Name = "Leidy Tatina",
                LastName = "Sanchez Arevalo",
                TypeIdentificationId = 1,
                Identification = "1110544973",
                Email = "ltsa0314@gmail.com",
                Password = "Tatiana@2021"
            };

            context.Users.Add(entity);
            context.SaveChanges();

            // Act
            var repository = new UserRepository(context);
            var entityFind = repository.GetById(entity.Id);


            // Assert
            Assert.True(entityFind != null);
            Assert.True(entity.Name == "Leidy Tatina");
            Assert.True(entity.LastName == "Sanchez Arevalo");
            Assert.True(entity.TypeIdentificationId == 1);
            Assert.True(entity.Identification == "1110544973");
            Assert.True(entity.Email == "ltsa0314@gmail.com");
            Assert.True(entity.Password == "Tatiana@2021");

        }

        [Fact]
        public void GetAll()
        {
            // Arrange
            var builder = new DbContextOptionsBuilder<CarvajalDbContext>();
            var options = builder.UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
            using var context = new CarvajalDbContext(options);
            context.Database.EnsureDeleted();

            var entity = new User
            {
                Name = "Leidy Tatina",
                LastName = "Sanchez Arevalo",
                TypeIdentificationId = 1,
                Identification = "1110544973",
                Email = "ltsa0314@gmail.com",
                Password = "Tatiana@2021"
            };

            context.Users.Add(entity);
            context.SaveChanges();


            // Action
            var repository = new UserRepository(context);
            var entities = repository.GetAll();

            // Assert
            Assert.True(entities != null);
            Assert.True(entities.Count() > 0);
            Assert.True(entities.LastOrDefault().Name == "Leidy Tatina");
        }
    }
}
