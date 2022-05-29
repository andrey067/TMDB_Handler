using MediatR;
using Tmdb.Core.Results;
using Tmdb.Infra.Interfaces;
using Tmdb.Services.UseCases;

namespace Tmdb.Services.Handlers.Queries
{
    public class FindAllMoviesHandler : IRequestHandler<FindAllMoviesRequest, ResultModel>
    {
        private ITbdmSearchRepository _tmdbRepository;

        public FindAllMoviesHandler(ITbdmSearchRepository tmdbRepository)
        {
            _tmdbRepository = tmdbRepository;
        }

        public async Task<ResultModel> Handle(FindAllMoviesRequest request, CancellationToken cancellationToken)
        {
            var resultSearch = await _tmdbRepository.FindAllMovies();


            return MovieResult.ReturnMovies(resultSearch);
        }
    }
}
