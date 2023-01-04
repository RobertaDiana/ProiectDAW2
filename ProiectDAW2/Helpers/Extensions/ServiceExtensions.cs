
using ProiectDAW2.Repositories.ProdusRepository;
using ProiectDAW2.Servicies;

namespace ProiectDAW2.Helpers.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IProduseRepository, ProduseRepository>();
            

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IProduseServicies, ProduseServicies>();
          

            return services;
        }

        public static IServiceCollection AddSeeders(this IServiceCollection services)
        {
            return services;
        }

        public static IServiceCollection AddUtils(this IServiceCollection services)
        { 

            return services;
        }
    }
}
