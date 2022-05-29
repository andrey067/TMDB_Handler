using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
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
    }
}
