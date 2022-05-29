using AutoMapper;
using MediatR;
using Tmdb.Core.Results;
using Tmdb.Domain.Entities;
using Tmdb.Infra.Interfaces;
using Tmdb.Services.UseCases;

namespace Tmdb.Services.Handlers.Commands
{
    public class AddMovieHandler : IRequestHandler<AddMovieCommand, ResultModel>
    {
        private readonly IUserRepository _userRepository;
        private readonly ITbdmSearchRepository _tbdmSearchRepository;
        private readonly IMapper _mapper;

        public AddMovieHandler(IUserRepository userRepository, ITbdmSearchRepository tbdmSearchRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _tbdmSearchRepository = tbdmSearchRepository;
            _mapper = mapper;
        }

        public async Task<ResultModel> Handle(AddMovieCommand request, CancellationToken cancellationToken)
        {
            var movieTmdb = await _tbdmSearchRepository.GetMovie(request.MovieId);

            if (movieTmdb is null)
                return UserResults.MovieNotFound();

            var movie = _mapper.Map<Movie>(movieTmdb);

            var user = await _userRepository.GetUser(request.UserId);
            if (user is null)
                return UserResults.UserNotFound();


            if (user.Profiles.Any(profile => profile.Name.Equals(request.ProfileName)) is false)
                return UserResults.UserNotFound();

            user.Profiles.ToList().ForEach(profile =>
            {
                if (profile.Name.Equals(request.ProfileName) && profile.Movies.Any(movie => movie.Id.Equals(movie.Id)) is false)
                    profile.Movies.Add(movie);
            });

            await _userRepository.Update(user);

            return UserResults.AddedMovie(user);
        }
    }
}
