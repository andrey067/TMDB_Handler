using Microsoft.EntityFrameworkCore;
using Tmdb.Domain.Entities;
using Tmdb.Infra.Context.Mappings;

namespace Tmdb.Infra.Context
{
    public class TmdbContext : DbContext
    {
        public TmdbContext(DbContextOptions<TmdbContext> options) : base(options) { }
        public DbSet<User> User => Set<User>();
        public DbSet<Movie> Movie => Set<Movie>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new UserMapping());            
        }
    }
}