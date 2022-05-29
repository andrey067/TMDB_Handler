using Refit;
using Tmdb.Core.DTOs;

namespace Tmdb.Infra.Interfaces
{
    public interface ITbdmSearchRepository
    {
        [Get("/movie/popular")]
        Task<TmdbDto> FindAllMovies();
    }
}