using Microsoft.Extensions.DependencyInjection;
using Tmdb.Infra.Interfaces;
using Tmdb.Infra.Repository;

namespace Tmdb.CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAutenticationRepository, AutenticationRepository>();
        }
    }
}