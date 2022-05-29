namespace Tmdb.Domain.Entities
{
    public class Movie
    {
        public int Id { get; private set; }
        public bool Adult { get; set; }
        public string Backdrop_path { get; set; }
        public int Genre_ids { get; set; }
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

        public Movie(int id, bool adult,
            string backdrop_path,
            int genre_ids,
            string original_language,
            string original_title,
            string overview,
            double popularity,
            string poster_path,
            string release_date,
            string title,
            bool video,
            double vote_average,
            int vote_count)
        {
            Id = id;
            Adult = adult;
            Backdrop_path = backdrop_path;
            Genre_ids = genre_ids;
            Original_language = original_language;
            Original_title = original_title;
            Overview = overview;
            Popularity = popularity;
            Poster_path = poster_path;
            Release_date = release_date;
            Title = title;
            Video = video;
            Vote_average = vote_average;
            Vote_count = vote_count;
        }
    }
}