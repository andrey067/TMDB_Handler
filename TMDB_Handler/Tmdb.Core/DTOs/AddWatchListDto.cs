namespace Tmdb.Core.DTOs
{
    public class AddWatchListDto
    {
        public int UserId { get; set; }
        public string ProfileName { get; set; }
        public int MovieId { get; set; }
    }
}
