namespace Tmdb.Core.DTOs
{
    public class TmdbResults
    {
        public int Id { get; set; }
        public bool Adult { get; set; }
        public string Backdrop_path { get; set; }
        public List<int> Genre_ids { get; set; }
        public string Original_language { get; set; }
        public string Original_title { get; set; }
        public string Overview { get; set; }
        public double Popularity { get; set; }
        public string Poster_path { get; set; }
        public string Release_date { get; set; }
        public string Title { get; set; }
        public bool Video { get; set; }
        public double Vote_average { get; set; }
        public int Vote_count { get; set; }
    }
}
