using MediatR;
using Tmdb.Core.Results;
using Tmdb.Infra.Interfaces;
using Tmdb.Services.UseCases;

namespace Tmdb.Services.Handlers.Commands
{
    public class AddWatchedHandler : IRequestHandler<AddWatchedCommand, ResultModel>
    {
        private readonly IUserRepository _userRepository;

        public AddWatchedHandler(IUserRepository userRepository) => _userRepository = userRepository;


        public async Task<ResultModel> Handle(AddWatchedCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUser(request.UserId);
            if (user is null)
                return UserResults.UserNotFound();

            user.Profiles.ToList().ForEach(profile =>
            {
                profile.Movies.ToList().ForEach(movie =>
                {
                    if (movie.Id == request.MovieId)
                        movie.Watched = true;
                });
            });

            var userUpdated = await _userRepository.Update(user);
            return MovieResult.AddWatched(userUpdated);
        }
    }
}
