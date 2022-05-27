namespace Tmdb.Domain.ValueObject
{
    public class Profile
    {
        public string Nome { get; private set; }
        public List<Movie> Movie { get; private set; }
    }
}