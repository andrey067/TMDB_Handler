namespace Tmdb.Core.DTOs
{
    public class TmdbDto
    {
        public int page { get; set; }
        public List<TmdbResults> results { get; set; }
        public int total_pages { get; set; }
        public int total_results { get; set; }
    }
}
