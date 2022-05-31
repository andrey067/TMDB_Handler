using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Tmdb.Infra.Context;

namespace Fixtures
{
    public class DbTests
    {
        private string dataBaseName = $"dbApiTest_{Guid.NewGuid().ToString().Replace("-", string.Empty)}";
        public ServiceProvider ServiceProvider { get; private set; }

        public DbTests()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddDbContext<TmdbContext>(options =>
                options.UseSqlite($"Data Source={dataBaseName}.db")
                , ServiceLifetime.Transient);

            ServiceProvider = serviceCollection.BuildServiceProvider();
        }
    }
}
