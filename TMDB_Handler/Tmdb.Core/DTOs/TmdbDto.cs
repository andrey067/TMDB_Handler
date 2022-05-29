namespace Tmdb.Core.DTOs
{
    public class TmdbDto
    {
        public int Page { get; set; }
        public List<TmdbResults> Results { get; set; }
        public int Total_pages { get; set; }
        public int Total_results { get; set; }
    }
}
