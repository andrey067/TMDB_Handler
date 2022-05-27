namespace Tmdb.Infra.Context
{
    public class TmdbContext : DbContext
    {
        public TarefaDbContext(DbContextOptions<TmdbContext> options) : base(options) { }
        public DbSet<User> Tarefas => Set<User>();
    }
}