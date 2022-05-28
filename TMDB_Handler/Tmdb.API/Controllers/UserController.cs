using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Tmdb.API.ViewModels;
using Tmdb.Infra.UseCases;

namespace Tmdb.API.Controllers
{
    public class UserController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public UserController(IMapper mapper, IMediator mediator)
        {
            _mapper = mapper;
            _mediator = mediator;
        }

        [HttpPost]
        [Route("/api/v1/users/create")]
        public async Task<IActionResult> CreateAsync([FromBody] CreateUserDto userViewModel)
        {
            var userCommand = _mapper.Map<CreateUserCommand>(userViewModel);
            var resultadoCommando = await _mediator.Send(userCommand);

            return Ok(resultadoCommando);
        }
    }
}
