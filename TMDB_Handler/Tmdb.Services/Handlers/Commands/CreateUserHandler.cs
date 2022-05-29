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
        private IAutenticationRepository _autenticationRepository;
        private readonly IArgon2IdHasher _argon2IdHasher;

        public CreateUserHandler(IUserRepository userRepository, IAutenticationRepository autenticationRepository, IArgon2IdHasher argon2IdHasher)
        {
            _userRepository = userRepository;
            _autenticationRepository = autenticationRepository;
            _argon2IdHasher = argon2IdHasher;
        }

        public async Task<ResultModel> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var userExist = await _autenticationRepository.GetByEmail(request.Email);
            if (userExist != null)
                return UserResults.UserCreated("Já existe usuario cadastrado");

            var user = new User(request.Name, request.Email, request.Birthday);
            var autenticationUser = new User(request.Name, request.Email, _argon2IdHasher.Hash(request.Password), request.Birthday);

            user.Validate();
            user.AddProfile(Profile.CreateHostProfile(user.Name));
            await _userRepository.Create(user);
            await _autenticationRepository.Create(autenticationUser);
            return UserResults.UserCreated(user);
        }
    }
}
