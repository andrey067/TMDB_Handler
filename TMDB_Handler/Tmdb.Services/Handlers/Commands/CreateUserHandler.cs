using EscNet.Hashers.Interfaces.Algorithms;
using MediatR;
using Tmdb.Core.Results;
using Tmdb.Domain.Entities;
using Tmdb.Domain.ValueObject;
using Tmdb.Infra.Interfaces;
using Tmdb.Infra.UseCases;

namespace Tmdb.Services.Handlers.Commands
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, ResultModel>
    {
        private IUserRepository _userRepository;
        private readonly IArgon2IdHasher _argon2IdHasher;

        public CreateUserHandler(IUserRepository userRepository, IArgon2IdHasher argon2IdHasher)
        {
            _userRepository = userRepository;
            _argon2IdHasher = argon2IdHasher;
        }

        public async Task<ResultModel> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var userExist = await _userRepository.GetByEmail(request.Email);
            if (userExist != null)
                return UserResults.UserCreated("Já existe usuario cadastrado");

            var user = new User(request.Name, request.Email, _argon2IdHasher.Hash(request.Password), request.Birthday);

            user.Validate();
            user.AddProfile(Profile.CreateHostProfile(user.Name));
            await _userRepository.Create(user);
            return UserResults.UserCreated(user);
        }
    }
}
