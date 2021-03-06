using MediatR;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Tmdb.Core.DTOs;
using Tmdb.Core.Results;
using Tmdb.Services.UseCases;

namespace Tmdb.Services.Handlers.Queries
{
    public class SearchMovieHandler : IRequestHandler<SearchMovieRequest, ResultModel>
    {
        private readonly IConfiguration _configuration;

        public SearchMovieHandler(IConfiguration configuration) => _configuration = configuration;

        public async Task<ResultModel> Handle(SearchMovieRequest request, CancellationToken cancellationToken)
        {
            string querySearh = $"{_configuration["TmdbOptionsSettings:BaseUrl"]}/search/movie?api_key={_configuration["TmdbOptionsSettings:ApitKey"]}&query={request.Search}";
            var client = new HttpClient();

            using (var response = await client.GetAsync(querySearh))
            {
                var result = await response.Content.ReadAsStringAsync();
                var tmdbdto = JsonConvert.DeserializeObject<TmdbDto>(result);
                return MovieResult.ReturnMovies(tmdbdto.Results);
            }
        }
    }
}
