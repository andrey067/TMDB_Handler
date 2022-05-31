using Refit;
using Tmdb.Core.DTOs;

namespace Tmdb.Infra.Interfaces
{
    public interface ITbdmSearchRepository
    {
        [Get("/movie/popular")]
        Task<TmdbDto> GetAllMovies();

        [Get("/movie/{movieId}")]
        Task<TmdbResults> GetMovie([AliasAs("movieId")] int movieId);

        [Get("/")]
        Task<TmdbResults> SearchMovie();
    }
}