using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using Tmdb.CrossCutting.Http;
using Tmdb.Infra.Interfaces;

namespace Fixtures
{
    public class TmdbService
    {
        public ServiceProvider ServiceProvider { get; private set; }
        public IConfiguration Configuration { get; private set; }
        public TmdbService()
        {
            Configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
               .AddEnvironmentVariables().Build();

            var services = new ServiceCollection();

            string apikey = Configuration["TmdbOptionsSettings:ApitKey"];
            string baseUrl = Configuration["TmdbOptionsSettings:BaseUrl"];

            services.AddScoped(s => new ApiKeyMessageHandler(apikey));

            services.AddRefitClient<ITbdmSearchRepository>().ConfigureHttpClient(c =>
            {
                c.BaseAddress = new Uri(baseUrl);
            }).AddHttpMessageHandler<ApiKeyMessageHandler>();

            ServiceProvider = services.BuildServiceProvider();
        }

    }
}
