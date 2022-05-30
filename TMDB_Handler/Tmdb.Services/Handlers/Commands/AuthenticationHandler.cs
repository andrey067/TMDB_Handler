﻿using EscNet.Hashers.Interfaces.Algorithms;
using MediatR;
using Microsoft.Extensions.Options;
using Tmdb.Core.Options;
using Tmdb.Core.Results;
using Tmdb.Infra.Interfaces;
using Tmdb.Services.Token;
using Tmdb.Services.UseCases;

namespace Tmdb.Services.Handlers.Commands
{
    public class AuthenticationHandler : IRequestHandler<AuthenticationCommand, ResultModel>
    {
        private readonly IArgon2IdHasher _argon2IdHasher;
        private readonly ITokenGenerator _tokeGenerator;
        private readonly IUserRepository _userRepository;

        public AuthenticationHandler(IArgon2IdHasher argon2IdHasher, ITokenGenerator tokeGenerator, IOptions<SettingsJWTOptions> configuracaoJWTOptions)
        {
            _argon2IdHasher = argon2IdHasher;
            _tokeGenerator = tokeGenerator;
        }

        public async Task<ResultModel> Handle(AuthenticationCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByEmail(request.Email);

            if (user == null)
                return AuthenticationResult.EmailOrPassordInvalid();

            if (_argon2IdHasher.VerifyHashedText(request.Password, user.Password) is false)
                return AuthenticationResult.EmailOrPassordInvalid();

            return AuthenticationResult.Authenticated(_tokeGenerator.GenerateToken(user.Name));
        }
    }
}
