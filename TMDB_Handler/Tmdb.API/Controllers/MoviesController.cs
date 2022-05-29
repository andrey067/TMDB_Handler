using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tmdb.Core.DTOs;
using Tmdb.Services.UseCases;

namespace Tmdb.API.Controllers
{
    [Route("/api/v1/movie/")]
    public class MoviesController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public MoviesController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("FindAllMovies")]
        //[Authorize]
        public async Task<IActionResult> FindAllMovies()
        {
            var result = await _mediator.Send(new FindAllMoviesRequest());

            return Ok(result);
        }

        [HttpPut]
        [Route("/api/v1/users/addmovie")]
        public async Task<IActionResult> AddMovieAsync([FromBody] AddMovieDto movieViewModel)
        {
            var movieCommand = _mapper.Map<AddMovieCommand>(movieViewModel);
            var resultadoCommando = await _mediator.Send(movieCommand);

            return Ok(resultadoCommando);
        }

        [HttpGet]
        [Route("/api/v1/users/getmoviessuggested")]
        public async Task<IActionResult> GetMoviesSuggested([FromQuery] SuggestedDto suggestedDto)
        {
            var comandResult = await _mediator.Send(new GetMoviesSuggestedRequest(suggestedDto.UserId, suggestedDto.ProfileName));

            return Ok(comandResult);
        }

        [HttpGet]
        [Route("/api/v1/users/searchmovie")]
        public async Task<IActionResult> SearchMovie([FromQuery] string search)
        {
            var comandResult = await _mediator.Send(new SearchMovieRequest(search));

            return Ok(comandResult);
        }

        [HttpPut]
        [Route("/api/v1/users/addwatchlist")]
        public async Task<IActionResult> AddWatchList([FromQuery] AddWatchListDto addWatchListDto)
        {
            var addwatchlist = _mapper.Map<AddWatchListCommand>(addWatchListDto);

            var comandResult = await _mediator.Send(addwatchlist);

            return Ok(comandResult);
        }

        [HttpPut]
        [Route("/api/v1/users/addwatched")]
        public async Task<IActionResult> AddWatched([FromQuery] AddWatchedDto addWatchListDto)
        {
            var addwatchlist = _mapper.Map<AddWatchedCommand>(addWatchListDto);

            var comandResult = await _mediator.Send(addwatchlist);

            return Ok(comandResult);
        }
    }
}
