using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;

namespace Carvajal.Infraestructure.Data
{
    public class CarvajalDbContextFactory : IDesignTimeDbContextFactory<CarvajalDbContext>
    {
        public CarvajalDbContext CreateDbContext(string[] args)
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            return CreateDbContext(environment);
        }


        public CarvajalDbContext CreateDbContext(string environment)
        {

            // Configurar el Contexto para la migraciones desde el proyecto Infraestructure
            var builder = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings{environment}.json", true)
                .AddEnvironmentVariables();


            var config = builder.Build();
            var conectionString = config.GetSection("ConnectionStrings:CarvajalDb").Value;
            var optionsBuilder = new DbContextOptionsBuilder<CarvajalDbContext>();

            var options = optionsBuilder.UseSqlServer(conectionString).UseLazyLoadingProxies().Options;

            return new CarvajalDbContext(options);
        }
    }
}
