namespace Tmdb.Domain.ValueObject
{
    public class Movie
    {
        public int Id { get; private set; }
        public string Original_language { get; private set; }
        public string Original_title { get; private set; }
        public string Overview { get; private set; }
        public int Popularity { get; private set; }
        public string Poster_path { get; private set; }
        public string Release_date { get; private set; }
        public string Title { get; private set; }
        public bool Video { get; private set; }
        public string Vote_average { get; private set; }
        public bool Adult { get; private set; }
        public string Backdrop_path { get; private set; }
        public string Vote_count { get; private set; }
        public bool Assisted { get; private set; }
    }
}