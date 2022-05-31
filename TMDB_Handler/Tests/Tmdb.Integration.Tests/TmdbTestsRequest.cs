using Bogus;
using Fixtures;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System.Net;
using Tmdb.Core.DTOs;
using Tmdb.Infra.Interfaces;

namespace Tmdb.Integration.Tests
{
    public class TmdbTestsRequest : IClassFixture<TmdbService>
    {
        private readonly ServiceProvider _service;
        private ITbdmSearchRepository _tbdmSearchRepository;
        private IConfiguration _configuration;

        public TmdbTestsRequest(TmdbService service)
        {
            _service = service.ServiceProvider;
            _configuration = service.Configuration;
        }

        [Trait("Request", "Find All Movies")]
        [Fact(DisplayName = "É possivel realizar busca de filmes")]
        public async Task When_Make_Request_Get_Movies()
        {
            _tbdmSearchRepository = RefitService();
            var movies = await _tbdmSearchRepository.GetAllMovies();
            Assert.NotNull(movies);
        }

        [Trait("Request", "GetMovie")]
        [Fact(DisplayName = "É possivel realizar busca de filme por Id")]
        public async Task When_Make_Request_Find_Movie_By_Id()
        {
            _tbdmSearchRepository = RefitService();
            var movies = await _tbdmSearchRepository.GetMovie(new Faker().Random.Int(10, 5000));
            Assert.NotNull(movies);
        }

        [Trait("Request", "SearchMovie")]
        [Fact(DisplayName = "É possivel realizar busca de filmes por texto")]
        public async Task When_Make_Request_Find_Movie_By_text()
        {
            string text = new Faker().Person.FirstName;
            string querySearh = $"{_configuration["TmdbOptionsSettings:BaseUrl"]}/search/movie?api_key={_configuration["TmdbOptionsSettings:ApitKey"]}&query={text}";

            HttpClient client = new HttpClient();
            using (var response = await client.GetAsync(querySearh))
            {
                var result = await response.Content.ReadAsStringAsync();
                var tmdbdto = JsonConvert.DeserializeObject<TmdbDto>(result);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                Assert.NotNull(tmdbdto.Results);
            }
        }

        private ITbdmSearchRepository RefitService()
        {
            return _service.GetService<ITbdmSearchRepository>();
        }
    }
}
