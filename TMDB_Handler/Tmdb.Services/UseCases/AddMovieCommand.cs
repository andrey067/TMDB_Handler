using Tmdb.Core.Utils;

namespace Tmdb.Services.UseCases
{
    public class AddMovieCommand : CommandBase
    {
        public int MovieId { get; set; }
        public int UserId { get; set; }
        public string ProfileName { get; set; } = string.Empty;
    }
}
