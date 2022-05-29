using Tmdb.Core.Utils;

namespace Tmdb.Services.UseCases
{
    public class AddWatchedCommand : CommandBase
    {
        public int UserId { get; set; }
        public string ProfileName { get; set; } = string.Empty;
        public int MovieId { get; set; }
    }
}
