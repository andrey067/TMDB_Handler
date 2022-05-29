namespace Tmdb.Core.DTOs
{
    public class AddMovieDto
    {
        public int TMDBIdMovie { get; set; }
        public int UserId { get; set; }
        public string ProfileName { get; set; } = string.Empty;
    }
}
