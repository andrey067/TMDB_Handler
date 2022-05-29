using MediatR;
using Tmdb.Core.Results;
using Tmdb.Infra.Interfaces;
using Tmdb.Services.UseCases;

namespace Tmdb.Services.Handlers.Queries
{
    public class GetAllProfilesHandler : IRequestHandler<GetAllProfilesRequest, ResultModel>
    {
        private readonly IUserRepository _userRepository;

        public GetAllProfilesHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ResultModel> Handle(GetAllProfilesRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUser(request.UserId);

            if (user == null)
                return UserResults.UserNotFound();

            return UserResults.UserFound(user.Profiles.Select(profile => new
            {
                profile.Name,
                profile.TypeProfile
            }));
        }
    }
}
