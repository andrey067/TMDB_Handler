using Microsoft.EntityFrameworkCore;
using Tmdb.Domain.Entities;

namespace Tmdb.Infra.Context
{
    public class AuthenticationContext : DbContext
    {
        public AuthenticationContext(DbContextOptions<AuthenticationContext> options) : base(options) { }

        public DbSet<User> User => Set<User>();
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<User>().Ignore(p => p.IsValid);
            builder.Entity<User>().Ignore(p => p.Errors);
            builder.Entity<User>().Ignore(p => p.Profiles);
        }

    }
}
