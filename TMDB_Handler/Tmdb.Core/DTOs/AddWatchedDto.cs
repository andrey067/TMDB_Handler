namespace Tmdb.Core.DTOs
{
    public class AddWatchedDto
    {
        public int UserId { get; set; }
        public string ProfileName { get; set; } = string.Empty;
        public int MovieId { get; set; }
    }
}
