using Carvajal.Api.Helpers.AutoMapper;
using Carvajal.Domain.Interfaces;
using Carvajal.Infraestructure.Data;
using Carvajal.Infraestructure.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.OpenApi.Models;
using System.IO;

namespace Carvajal.Api.Helpers
{
    public class Ioc
    {
        public static IServiceCollection AddDbContext(IConfiguration configuration, IServiceCollection services)
        {
            services.AddDbContext<CarvajalDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("CarvajalDb")));

            return services;
        }

        public static IServiceCollection AddSwagger(IServiceCollection services)
        {
            // Swagger
            var basePath = PlatformServices.Default.Application.ApplicationBasePath;
            var xmlPath = Path.Combine(basePath, "Carvajal.Api.xml");

            services.AddSwaggerGen(config =>
            {
                config.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Title = "Carvajal Api",
                    Version = "v1",
                    Contact = new OpenApiContact()
                    {
                        Email = "ltsa0314@gmail.com",
                        Name = "Leidy Tatiana Sanchez ",
                    },
                });

                config.IncludeXmlComments(xmlPath);
            });
            return services;
        }

        public static IServiceCollection AddRepositories(IServiceCollection services)
        {
            // Transient , Scope , Singleton---- se resulven las instancias de los repositories
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ITypeIdentificationRepository, TypeIdentificationRepository>();
            return services;
        }

        public static IServiceCollection AddMappersConfig(IServiceCollection services)
        {
            return services.AddAutoMapper(AutoMapperConfig.RegisterMappings());
        }
    }
}
