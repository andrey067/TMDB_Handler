using MediatR;
using Tmdb.Core.Results;
using Tmdb.Infra.Interfaces;
using Tmdb.Services.UseCases;

namespace Tmdb.Services.Handlers.Commands
{
    public class AddMovieHandler : IRequestHandler<AddMovieCommand, ResultModel>
    {
        private readonly IUserRepository _userRepository;

        public AddMovieHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ResultModel> Handle(AddMovieCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
