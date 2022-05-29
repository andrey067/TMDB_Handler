using Tmdb.Core.Utils;

namespace Tmdb.Services.UseCases
{
    public class GetMoviesSuggestedRequest : CommandBase
    {
        public GetMoviesSuggestedRequest(int userId, string profileName)
        {
            UserId = userId;
            ProfileName = profileName;
        }

        public int UserId { get; set; }
        public string ProfileName { get; set; } = string.Empty;
    }
}
