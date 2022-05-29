using MediatR;
using Tmdb.Core.Results;
using Tmdb.Infra.Interfaces;
using Tmdb.Services.UseCases;

namespace Tmdb.Services.Handlers.Queries
{
    public class GetMoviesSuggestedHandler : IRequestHandler<GetMoviesSuggestedRequest, ResultModel>
    {
        private readonly IUserRepository _userRepository;

        public GetMoviesSuggestedHandler(IUserRepository userRepository) => _userRepository = userRepository;

        public async Task<ResultModel> Handle(GetMoviesSuggestedRequest request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetUser(request.UserId);
            if (user is null)
                return UserResults.UserNotFound();

            var profile = user.Profiles.Where(profile => profile.Name == request.ProfileName).FirstOrDefault();

            if (profile is null)
                return UserResults.UserNotFound();

            if (profile.Movies.Count == 0 || profile.Movies is null)
                return MovieResult.NoMoviesFound();

            return MovieResult.ReturnMovies(profile.Movies.Where(movie => movie.Watched == false).ToList());
        }
    }
}
