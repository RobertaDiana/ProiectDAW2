using Demo.Repositories.CategorieRepository;
using Demo.Repositories.ProduseInCategorieRepository;
using Demo.Repositories.ProducatorRepository;
using Demo.Repositories.ProdusRepository;
using Microsoft.Extensions.DependencyInjection;
using ProiectDAW2.Helpers.Jwt;
using ProiectDAW2.Helpers.Seeders;
using ProiectDAW2.Servicies;

namespace ProiectDAW2.Helpers.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IProduseRepository, ProduseRepository>();
            services.AddTransient<ICategorieRepository, CategorieRepository>();
            services.AddTransient<IProduseInCategorieRepository, ProduseInCategorieRepository>();
            services.AddTransient<IProducatorRepository, ProducatorRepository>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IProduseServicies, ProduseServicies>();
            services.AddTransient<ICategorieService, CategorieServicies>();
            services.AddTransient<IProducatorService, ProducatorService>();

            return services;
        }

        public static IServiceCollection AddSeeders(this IServiceCollection services)
        {
            services.AddTransient<ProduseSeeder>();
            return services;
        }

        public static IServiceCollection AddUtils(this IServiceCollection services)
        {
            services.AddTransient<IJwtUtils, JwtUtils>();

            return services;
        }
    }
}
