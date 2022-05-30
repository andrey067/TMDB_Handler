using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tmdb.API.ViewModels;
using Tmdb.Core.DTOs;
using Tmdb.Infra.UseCases;
using Tmdb.Services.UseCases;

namespace Tmdb.API.Controllers
{
    [Route("/api/v1/users/")]
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
        [Route("createUser")]
        public async Task<IActionResult> CreateAsync([FromBody] CreateUserDto userViewModel)
        {
            var userCommand = _mapper.Map<CreateUserCommand>(userViewModel);
            var resultadoCommando = await _mediator.Send(userCommand);

            return Ok(resultadoCommando);
        }

        [HttpGet]
        [Route("getProfiles")]
        [Authorize]
        public async Task<IActionResult> GetAllProfiles(int userId)
        {
            var userCommand = new GetAllProfilesRequest(userId);
            var resultadoQuery = await _mediator.Send(userCommand);
            return Ok(resultadoQuery);
        }


        [HttpPut]
        [Route("addprofile")]
        [Authorize]
        public async Task<IActionResult> AddProfileAsync([FromBody] AddProfileDto profileViewModel)
        {
            var profileCommand = _mapper.Map<AddProfileCommand>(profileViewModel);
            var resultadoCommando = await _mediator.Send(profileCommand);

            return Ok(resultadoCommando);
        }
    }
}
