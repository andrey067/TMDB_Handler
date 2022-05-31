using AutoMapper;
using MediatR;
using Tmdb.Core.Results;
using Tmdb.Domain.Entities;
using Tmdb.Infra.Interfaces;
using Tmdb.Services.UseCases;

namespace Tmdb.Services.Handlers.Commands
{
    public class AddWatchListHandler : IRequestHandler<AddWatchListCommand, ResultModel>
    {
        private readonly IUserRepository _userRepository;
        private readonly ITbdmSearchRepository _tmdbRepository;
        private readonly IMapper _mapper;

        public AddWatchListHandler(ITbdmSearchRepository tmdbRepository, IUserRepository userRepository, IMapper mapper)
        {
            _tmdbRepository = tmdbRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<ResultModel> Handle(AddWatchListCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = await _userRepository.GetUser(request.UserId);
                if (user is null)
                    return UserResults.UserNotFound();

                if (user.Profiles.ToList().Exists(x => x.Name == request.ProfileName) is false)
                    return UserResults.UserNotFound();

                var tmdbdto = await _tmdbRepository.GetMovie(request.MovieId);
                if (tmdbdto is null)
                    return MovieResult.NoMoviesFound();

                var movie = _mapper.Map<Movie>(tmdbdto);
                movie.Watchlist = true;

                user.Profiles.ToList().ForEach(profile =>
                {
                    if (profile.Name == request.ProfileName)
                    {
                        if (profile.Movies.Any(movie => movie.Id.Equals(movie.Id)))
                            profile.Movies.ForEach(m =>
                            {
                                if (movie.Id.Equals(m.Id))
                                    m.Watchlist = true;
                            });
                        else
                            profile.Movies.Add(movie);
                    }
                });

                await _userRepository.Update(user);

                return MovieResult.AddWatchList(user);
            }
            catch (Exception ex)
            {
                return ResultBase.ApplicationErrorMessage(ex.Message);
            }
        }
    }
}
