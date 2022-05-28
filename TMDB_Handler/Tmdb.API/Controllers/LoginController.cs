using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tmdb.API.ViewModels;
using Tmdb.Services.UseCases;

namespace Tmdb.API.Controllers
{
    public class LoginController : BaseController
    {
        [AllowAnonymous]
        [HttpPost]
        [Route("/api/v1/auth/login")]
        public async Task<IActionResult> Login([FromServices] IMapper _mapper,
                                               [FromServices] IMediator _mediator,
                                               [FromBody] LoginDto loginDto)
        {
            var login = _mapper.Map<AuthenticationCommand>(loginDto);
            var commandResult = await _mediator.Send(login);
            if (commandResult.Success)
                return Ok(commandResult.Data);
            return BadRequest(commandResult.Message);
        }
    }
}