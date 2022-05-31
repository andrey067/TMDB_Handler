using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tmdb.Core.DTOs;
using Tmdb.Services.UseCases;

namespace Tmdb.API.Controllers
{
    [Route("/api/v1/movies/")]
    public class MoviesController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public MoviesController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("find-all-movies")]
        //[Authorize]
        public async Task<IActionResult> FindAllMovies()
        {
            var result = await _mediator.Send(new FindAllMoviesRequest());

            return Ok(result);
        }

        [HttpPut]
        [Route("add-movie")]
        [Authorize]
        public async Task<IActionResult> AddMovieAsync([FromBody] AddMovieDto movieViewModel)
        {
            var movieCommand = _mapper.Map<AddMovieCommand>(movieViewModel);
            var resultadoCommando = await _mediator.Send(movieCommand);

            return Ok(resultadoCommando);
        }

        [HttpGet]
        [Route("get-movies-suggested")]
        [Authorize]
        public async Task<IActionResult> GetMoviesSuggested([FromQuery] SuggestedDto suggestedDto)
        {
            var comandResult = await _mediator.Send(new GetMoviesSuggestedRequest(suggestedDto.UserId, suggestedDto.ProfileName));

            return Ok(comandResult);
        }

        [HttpGet]
        [Route("search-movie")]
        [Authorize]
        public async Task<IActionResult> SearchMovie([FromQuery] string search)
        {
            var comandResult = await _mediator.Send(new SearchMovieRequest(search));

            return Ok(comandResult);
        }

        [HttpPut]
        [Route("add-watch-list")]
        [Authorize]
        public async Task<IActionResult> AddWatchList([FromQuery] AddWatchListDto addWatchListDto)
        {
            var addwatchlist = _mapper.Map<AddWatchListCommand>(addWatchListDto);

            var comandResult = await _mediator.Send(addwatchlist);

            return Ok(comandResult);
        }

        [HttpPut]
        [Route("add-watched")]
        [Authorize]
        public async Task<IActionResult> AddWatched([FromQuery] AddWatchedDto addWatchListDto)
        {
            var addwatchlist = _mapper.Map<AddWatchedCommand>(addWatchListDto);

            var comandResult = await _mediator.Send(addwatchlist);

            return Ok(comandResult);
        }
    }
}
