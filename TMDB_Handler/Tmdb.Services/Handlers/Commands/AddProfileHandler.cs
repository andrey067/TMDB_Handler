using MediatR;
using Tmdb.Core.Results;
using Tmdb.Domain.Entities;
using Tmdb.Domain.ValueObject;
using Tmdb.Infra.Interfaces;
using Tmdb.Services.UseCases;

namespace Tmdb.Services.Handlers.Commands
{
    public class AddProfileHandler : IRequestHandler<AddProfileCommand, ResultModel>
    {
        private IUserRepository _userRepository;
        private const int _maxProfileCount = 5;
        public AddProfileHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ResultModel> Handle(AddProfileCommand request, CancellationToken cancellationToken)
        {
            try
            {
                User user = await _userRepository.GetUser(request.UserId);

                if (user is null)
                    return UserResults.UserNotFound();

                if (user.Profiles.Count() >= _maxProfileCount)
                    return UserResults.MaxProfile();

                if (user.Profiles.Any(profile => profile.Name.Equals(request.NameProfile)))
                    return UserResults.UserAlreadyExists();

                user.AddProfile(Profile.CreateGuestProfile(request.NameProfile));
                user.Validate();
                await _userRepository.Update(user);

                return UserResults.UserCreated(user);
            }
            catch (Exception ex)
            {
                return ResultBase.ApplicationErrorMessage(ex.Message);
            }
        }
    }
}
